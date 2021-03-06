﻿using System.Web.Http;

namespace LookingForGroup
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            config.Routes.MapHttpRoute(
                name: "Party",
                routeTemplate: "api/{controller}/{viewModel}/{festivalId}",
                defaults: new { viewModel = new ViewModels.GroupViewModel(), festivalId =RouteParameter.Optional}
            );
             config.Routes.MapHttpRoute(
                name: "EditParty",
                routeTemplate: "api/{controller}/{viewModel}/{partyId}/{email}/{password}",
                defaults: new { viewModel = new ViewModels.GroupViewModel() ,partyId=RouteParameter.Optional,email=RouteParameter.Optional,password=RouteParameter.Optional}
            );
           //  config.Routes.MapHttpRoute(
           //    name: "EditParty",
           //    routeTemplate: "api/{controller}/{viewModel}",
           //    defaults: new { viewModel = new ViewModels.GroupViewModel() }
           //);
             config.Routes.MapHttpRoute(
               name: "Join",
               routeTemplate: "api/{controller}/{partyId}/{email}"
           );
            
            // Uncomment the following line of code to enable query support for actions with an IQueryable or IQueryable<T> return type.
            // To avoid processing unexpected or malicious queries, use the validation settings on QueryableAttribute to validate incoming queries.
            // For more information, visit http://go.microsoft.com/fwlink/?LinkId=279712.
            //config.EnableQuerySupport();

            // To disable tracing in your application, please comment out or remove the following line of code
            // For more information, refer to: http://www.asp.net/web-api
            config.EnableSystemDiagnosticsTracing();
        }
    }
}
