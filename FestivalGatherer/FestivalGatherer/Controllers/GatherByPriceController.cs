using System.Net.Http;
using System.Web.Http;
using FestivalGatherer.DataProviders;
using FestivalGatherer.Models;
using FestivalGatherer.Utilities;

namespace FestivalGatherer.Controllers
{
    public class GatherByPriceController : ApiController
    {
        [System.Web.Http.HttpGet]
        public HttpResponseMessage Get(string minPrice, string maxPrice)
        {
            var festivals = Provider.QuerryFestivalsByPrice(minPrice,maxPrice);
            var myFestivals = new Festivals(festivals);
            //return Json.Encode(myFestivals);
            return new HttpResponseMessage()
            {
                Content = new JsonContent(myFestivals)
            };
        }
    }
}