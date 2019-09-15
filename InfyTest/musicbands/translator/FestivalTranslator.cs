using musicbands.Models.ui;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace musicbands.translator
{
    public class TreeView
    {
        public string id { get; set; }
        public string parent { get; set; }
        public string text { get; set; }

    }

    public class Transltor
    {
        public List<TreeView> TranslateFesticalApi(List<Festival> apidata)
        {
            var result = new List<TreeView>();

            var labels = (from f in apidata
                          from b in f.Bands
                          orderby b.Label.Name ascending
                          select b.Label).Distinct().ToList();

            foreach (RecordLabel lbl in labels)
                result.Add(new TreeView { id = $"rl{lbl.Id}", parent = "#", text = lbl.Name });

            var bands = (from f in apidata
                         from b in f.Bands
                         orderby b.Name ascending
                         select b).ToList();

            foreach (Band bd in bands)
            {
                if (result.FindIndex(dt => dt.id == $"bd{bd.Id}") < 0)
                    result.Add(new TreeView { id = $"bd{bd.Id}", parent = $"rl{bd.Label.Id}", text = bd.Name });

                var festivals = (from f in apidata
                                 from b in f.Bands
                                 where b.Id == bd.Id
                                 orderby f.Name ascending
                                 select f).ToList();

                foreach (Festival fs in festivals)
                {
                    if (result.FindIndex(dt => dt.id == $"fs{fs.Id}bd{bd.Id}") < 0)
                        result.Add(new TreeView { id = $"fs{fs.Id}bd{bd.Id}", parent = $"bd{bd.Id}", text = fs.Name });
                }

            }


            return result;
        }
    }
}
