using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;

namespace musicbands.Models.ui
{
    public class LabelModel
    {
        public List<TreeJson> GetTreeModel()
        {
            var data = new List<TreeJson>();

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:53849/api/");
                var responseTask = client.GetAsync("festivals");
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsStringAsync().Result;
                    var apidata = JsonConvert.DeserializeObject<List<Festival>>(readTask);

                    var labels = (from f in apidata
                                  from b in f.Bands
                                  orderby b.Label.Name ascending
                                  select b.Label).Distinct().ToList();

                    foreach (RecordLabel lbl in labels)
                        data.Add(new TreeJson {id=$"rl{lbl.Id}", parent = "#", text = lbl.Name });

                    var bands = (from f in apidata
                                 from b in f.Bands
                                 orderby b.Name ascending
                                 select b).ToList();

                   

                    foreach (Band bd in bands)
                    {
                        if(data.FindIndex(dt => dt.id == $"bd{bd.Id}") < 0)
                            data.Add(new TreeJson { id = $"bd{bd.Id}", parent = $"rl{bd.Label.Id}", text = bd.Name });

                        var festivals = (from f in apidata
                                         from b in f.Bands
                                         where b.Id == bd.Id
                                         orderby f.Name ascending
                                         select f).ToList();

                        foreach (Festival fs in festivals)
                        {
                            if (data.FindIndex(dt => dt.id == $"fs{fs.Id}bd{bd.Id}") < 0)
                                data.Add(new TreeJson { id = $"fs{fs.Id}bd{bd.Id}", parent = $"bd{bd.Id}", text = fs.Name });
                        }

                    }
                }
            }

            return data;
        }
    }

    public class TreeJson
    {
        public string id { get; set; }
        public string parent { get; set; }
        public string text { get; set; }
    }

}
