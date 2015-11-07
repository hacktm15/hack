using System.Web.Http;
using System.Web.Routing;
using FestivalGatherer.Utilities;

namespace FestivalGatherer.Controllers
{
    public class HashTestController : ApiController
    {
        [System.Web.Http.HttpGet]
        public string Get(string apiKey, string secretKey, string querry = "year=2015")
        {

            var fullQuerry = HmcSha1.Hash2(apiKey, secretKey, querry);
            return fullQuerry;
        }

        
    }
}