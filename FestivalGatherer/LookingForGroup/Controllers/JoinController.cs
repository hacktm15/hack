using System.Net.Http;
using System.Web.Http;
using FestivalTracker.Utilities.Utilities;
using LookingForGroup.Providers;

namespace LookingForGroup.Controllers
{
    public class JoinController:ApiController
    {
        [HttpGet]
        public HttpResponseMessage Get(int partyId,string email)
        {
            using (var provider = new Provider())
            {
                var result = provider.JoinParty(partyId,email);
                return new HttpResponseMessage
                {
                    Content = new JsonContent(result)
                };
            }
        }
    }
}