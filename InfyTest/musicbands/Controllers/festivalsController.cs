using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using musicbands.Repository;
using Newtonsoft.Json;

namespace musicbands.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FestivalsController : ControllerBase
    {
        private readonly IFestivalRepo festivalRepo;

        public FestivalsController(IFestivalRepo _festivalRepo)
        {
            festivalRepo = _festivalRepo;
        }

        // GET: api/festivals
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(JsonConvert.SerializeObject(festivalRepo.GetFestivals()));
        }
    }
}
