using System;
using System.Net.Http;
using System.Web.Http;
using FestivalGatherer.DataProviders;
using FestivalGatherer.Models;
using FestivalGatherer.Utilities;

namespace FestivalGatherer.Controllers
{
    public class GatherByDateController : ApiController
    {
        [System.Web.Http.HttpGet]
        public HttpResponseMessage Get(DateTime startDate)
        {
            var dateUrl = startDate.ToString("yyyy-MM-dd HH:mm:ss");
            var festivals = Provider.QuerryFestivalsByDate(dateUrl);
            var myFestivals = new Festivals(festivals, dateUrl);
            //return Json.Encode(myFestivals);
            return new HttpResponseMessage()
            {
                Content = new JsonContent(myFestivals)
            };
        }
    }
}