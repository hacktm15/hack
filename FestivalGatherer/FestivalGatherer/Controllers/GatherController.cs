using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Helpers;
using System.Web.Http;
using System.Web.Mvc;

namespace FestivalGatherer.Controllers
{
    public class Festival
    {
        public string Date { get; set; }

        public string Name { get; set; }
    }
    public class GatherController : ApiController
    {
        // GET api/values
        [System.Web.Http.HttpGet]
        public string Get()
        {
            var festival = new Festival {Date = DateTime.Now.ToString(CultureInfo.InvariantCulture), Name = "Test"};
            return Json.Encode(festival);
        }

        //// GET api/values/5
        //public string Get(int id)
        //{
        //    return "value";
        //}

        //// POST api/values
        //public void Post([FromBody]string value)
        //{
        //}

        //// PUT api/values/5
        //public void Put(int id, [FromBody]string value)
        //{
        //}

        //// DELETE api/values/5
        //public void Delete(int id)
        //{
        //}
    }
}