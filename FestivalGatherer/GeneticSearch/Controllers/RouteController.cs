using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Web.Http;
using FestivalTracker.Utilities.Utilities;
using GeneticSearch.Provider;

namespace GeneticSearch.Controllers
{
    public class RouteController : ApiController
    {
        // GET api/values
        [System.Web.Http.HttpGet]
        public HttpResponseMessage Get(string start, string stop)
        {
            var result = RouteProvider.Querry(start, stop);
            return new HttpResponseMessage()
            {
                Content = new JsonContent(result)
            };
        }
    }
}