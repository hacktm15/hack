using System;
using System.Collections.Generic;
using System.Configuration.Provider;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Web.Helpers;
using System.Web.Http;
using System.Web.Mvc;

namespace FestivalGatherer.Controllers
{
    public class Festival
    {
        public string Date { get; set; }
        public string Name { get; set; }
        public string Price { get; set; }
        public string Location { get; set; }
        public string ImagePath { get; set; }
    }
    public class GatherController : ApiController
    {
        // GET api/values
        [System.Web.Http.HttpGet]
        public string Get()
        {
            Provider.QuerryFestivals();
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

    public class Provider
    {
        public static void QuerryFestivals()
        {
            string requestUrl = HmcSha1.Hash2("qXVl3oyM75QhQtz4", "MWR6cePblwXxSg38vqAzbJ2rg6u6ykcz", "year=2015");
            var request = (HttpWebRequest) WebRequest.Create(requestUrl);
            request.Accept="application/json;ver=2.0";
            using (var response = (HttpWebResponse) request.GetResponse())
            {
                Stream receiveStream = response.GetResponseStream();
                if (receiveStream == null)
                {
                    return;
                }
                using (var readStream = new StreamReader(receiveStream, Encoding.UTF8))
                {
                    var x = readStream.ReadToEnd();
                }
            }
        }
    }
}