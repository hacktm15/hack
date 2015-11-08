using System.Data.Common.CommandTrees;
using System.Linq;
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
        [HttpGet]
        public HttpResponseMessage Get(string festivalId)
        {
            using (var provider = new Provider())
            {
                var result = provider.QuerryByFestival(festivalId);
                var join = from party in result
                    orderby party.PartyMembers.Count
                    select new {party.GroupInfo, party.Leader.EmailAddress, party.PartyMembers.Count};
                return new HttpResponseMessage
                {
                    Content = new JsonContent(join)
                };
            }
        }
      
    }
}