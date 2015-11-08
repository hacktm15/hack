using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using FestivalTracker.Utilities.Utilities;
using GeneticSearch.Provider;

namespace GeneticSearch.Controllers
{
    public class FlightController:ApiController
    {
     
           [System.Web.Http.HttpGet]
        public HttpResponseMessage Get(string start, string stop, string startDate, string returnDate)
        {
            var result = RouteProvider.QuerryFlight(start, stop,startDate,returnDate);
            return new HttpResponseMessage()
            {
                Content = new JsonContent(result)
            };
        }
    }
}