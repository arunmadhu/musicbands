using musicbands.Models.api;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace musicbands.Repository
{
    public interface IFestivalRepo
    {
        List<Festival> GetFestivals();
    }
}
