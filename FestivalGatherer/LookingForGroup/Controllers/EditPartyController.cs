using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using FestivalTracker.Utilities.Utilities;
using LookingForGroup.Providers;
using LookingForGroup.ViewModels;

namespace LookingForGroup.Controllers
{
    public class EditPartyController:ApiController
    {
        [HttpPost]
        public HttpResponseMessage Post(GroupViewModel viewModel)
        {
            using (var provider = new Provider())
            {
                var result = provider.EditGroup(viewModel);
                return new HttpResponseMessage
                {
                    Content = new JsonContent(result)
                };
            }
        }

        [HttpGet]
        public HttpResponseMessage Get(int partyId,string email,string password)
        {
            using (var provider = new Provider())
            {
                var result = provider.CanEditGroup(partyId,email,password);
                return new HttpResponseMessage
                {
                    Content = new JsonContent(result)
                };
            }
        }
    }
}