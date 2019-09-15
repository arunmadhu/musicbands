using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace musicbands.Models.ui
{
    public class LabelModel
    {
        public TreeView GetTreeModel()
        {
            TreeView viewModel = new TreeView();

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:53849/api/");
                //HTTP GET
                var responseTask = client.GetAsync("festivals");
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {

                    var readTask = result.Content.ReadAsStringAsync().Result;
                    var festivals = JsonConvert.DeserializeObject<List<Festival>>(readTask);

                    viewModel.Labels = (from f in festivals
                                  from b in f.Bands
                                  orderby b.Label.Name ascending
                                  select b.Label).Distinct().ToList();

                    viewModel.Bands = (from f in festivals
                                       from b in f.Bands
                                       orderby b.Name ascending
                                       select b).ToList();

                    viewModel.Festivals = (from f in festivals
                                           orderby f.Name ascending
                                           select f).ToList();

                }
            }

            return viewModel;
        }
    }

    public class TreeView
    {
        public List<RecordLabel> Labels { get; set; }

        public List<Band> Bands { get; set; }

        public List<Festival> Festivals { get; set; }
    }

}
