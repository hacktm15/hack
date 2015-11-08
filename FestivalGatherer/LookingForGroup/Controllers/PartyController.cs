using System.Data.Common.CommandTrees;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using FestivalTracker.Utilities.Utilities;
using LookingForGroup.Providers;
using LookingForGroup.ViewModels;

namespace LookingForGroup.Controllers
{
    public class PartyController : ApiController
    {
        // GET api/values
        [HttpPost]
        public HttpResponseMessage Post(GroupViewModel viewModel)
        {
            using (var provider = new Provider())
            {
                var result = provider.CreateGroup(viewModel);
                return new HttpResponseMessage
                {
                    Content = new JsonContent(result)
                };
            }
        }

        // GET api/values/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
        }
    }
}