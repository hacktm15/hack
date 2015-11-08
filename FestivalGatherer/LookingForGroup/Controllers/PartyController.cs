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
                return new HttpResponseMessage
                {
                    Content = new JsonContent(result)
                };
            }
        }
      
    }
}