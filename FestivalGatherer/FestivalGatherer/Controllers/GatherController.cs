using System.Web.Helpers;
using System.Web.Http;
using FestivalGatherer.DataProviders;
using FestivalGatherer.Models;

namespace FestivalGatherer.Controllers
{
    public class GatherController : ApiController
    {
        // GET api/values
        [System.Web.Http.HttpGet]
        public string Get()
        {
            var festivals = Provider.QuerryFestivals();
            var myFestivals = new Festivals(festivals);
            return Json.Encode(myFestivals);
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