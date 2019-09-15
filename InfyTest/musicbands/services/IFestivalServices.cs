using musicbands.Models.ui;
using System.Collections.Generic;

namespace musicbands.services
{
    public interface IFestivalServices
    {
        List<Festival> GetFestivals();
    }
}
