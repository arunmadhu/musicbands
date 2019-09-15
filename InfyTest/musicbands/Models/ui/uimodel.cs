using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace musicbands.Models.ui
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

        public override bool Equals(object obj)
        {
            var other = obj as Band;

            if (other == null)
            {
                return false;
            }

            return (this.Name == other.Name);
        }

        public override int GetHashCode()
        {
            return this.Id;
        }
    }

    public class RecordLabel
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public override bool Equals(object obj)
        {
            var other = obj as RecordLabel;

            if (other == null)
            {
                return false;
            }

            return (this.Name == other.Name);
        }

        public override int GetHashCode()
        {
            return this.Id;
        }
    }
}
