using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace musicbands.Models.api
{
    public class Festival
    {
        public int Id { get; set; }

        public string Name { get; set; }
        public List<Band> Bands { get; set; }

    }

    public class Band
    {

        public int Id { get; set; }
        public string Name { get; set; }

        public RecordLabel Label { get; set; }
    }

    public class RecordLabel
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
