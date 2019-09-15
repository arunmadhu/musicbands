using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using musicbands.Models.api;

namespace musicbands.Repository
{
    public class FestivalRepo : IFestivalRepo
    {
        public List<Festival> GetFestivals()
        {
            var label1 = new RecordLabel { Id = 1, Name = "Record Label1" };
            var label2 = new RecordLabel { Id = 2, Name = "Record Label2" };
            var label3 = new RecordLabel { Id = 3, Name = "Record Label3" };

            var band1 = new Band { Id = 1, Name = "Band A1", Label = label1 };
            var band2 = new Band { Id = 2, Name = "Band A2", Label = label1 };
            var band3 = new Band { Id = 3, Name = "Band B1", Label = label2 };
            var band4 = new Band { Id = 4, Name = "Band B2", Label = label2 };
            var band5 = new Band { Id = 5, Name = "Band C1", Label = label3 };
            var band6 = new Band { Id = 6, Name = "Band C2", Label = label3 };

            var f1Bands = new List<Band>();
            f1Bands.Add(band1);
            f1Bands.Add(band4);
            f1Bands.Add(band6);

            var f1 = new Festival { Id = 1, Name = "Omega-NSW" };
            f1.Bands = new List<Band> { band1, band4, band6 };

            var f2 = new Festival { Id = 2, Name = "Theta-VIC" };
            f2.Bands = new List<Band> { band2, band5 };

            var f3 = new Festival { Id = 3, Name = "Alpha-QLD" };
            f3.Bands = new List<Band> { band3, band6 };

            var f4 = new Festival { Id = 4, Name = "Beta-TAS" };
            f4.Bands = new List<Band> { band3,band5, band6 };

            var festivals = new List<Festival> { f1, f2, f3, f4 };

            return festivals;
        }
    }
}
