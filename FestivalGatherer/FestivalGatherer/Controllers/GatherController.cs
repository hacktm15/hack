using System;
using System.Globalization;
using System.Linq;
using System.Net.Http;
using System.Web.Helpers;
using System.Web.Http;
using FestivalGatherer.DataProviders;
using FestivalGatherer.Models;
using FestivalTracker.Utilities.Utilities;

namespace FestivalGatherer.Controllers
{
    public class GatherController : ApiController
    {
        
        [System.Web.Http.HttpGet]
        public HttpResponseMessage Get(DateTime startDate, string minPrice = "", string maxPrice = "")
        {
            string date = startDate.ToString("yyyy-MM-dd HH:mm:ss");
            var festivals = Provider.QuerryFestivals(minPrice,maxPrice,date);
            var myFestivals = new Festivals(festivals, date);
            return new HttpResponseMessage
            {
                Content = new JsonContent(myFestivals)
            };
        }
        
    }
}