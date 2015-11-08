using System;
using System.Net.Http;
using System.Web.Http;
using CrashHelper.Models;
using CrashHelper.Provider;
using FestivalTracker.Utilities.Utilities;

namespace CrashHelper.Controllers
{
    public class FindController : ApiController
    {
        // GET api/values
        [System.Web.Http.HttpGet]
        public HttpResponseMessage Get(string latitude,string longitude,DateTime date)
        { 
            var unixDate= (Int32)(date.Subtract(new DateTime(1970, 1, 1))).TotalSeconds;
            var result = CrashPlaceProvider.Querry(latitude, longitude, unixDate);
            var places = new CrashPlaces(result.result);
            return new HttpResponseMessage()
            {
                Content = new JsonContent(places)
            };
        }
    }
}