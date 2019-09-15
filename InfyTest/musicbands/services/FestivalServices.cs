using musicbands.Models.ui;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace musicbands.services
{
    public class FestivalServices : IFestivalServices
    {
        public List<Festival> GetFestivals()
        {
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

                    return apidata;
                }
                else
                    return null;
            }
        }
    }
}
