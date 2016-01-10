using System.Web.Http;
using Investor.Common.Shared.IoC;
using Microsoft.Practices.Unity;
using Investor.Common.Service.Client.Interface;
using Investor.Common.Service.Client.Data;
using Investor.Common.Service.Client.Logic;

namespace Investor.Common.Service.Client.Api
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services

            // Web API routes
            config.MapHttpAttributeRoutes();

            //config.Routes.MapHttpRoute(
            //    name: "DefaultApi",
            //    routeTemplate: "api/{controller}/{id}",
            //    defaults: new { id = RouteParameter.Optional }
            //);

            var container = new UnityContainer();
            container.RegisterType<IClientRepository, ClientRepository>(new HierarchicalLifetimeManager());
            container.RegisterType<IClientLogic, ClientLogic>(new HierarchicalLifetimeManager());

            config.DependencyResolver = new UnityResolver(container);
        }
    }
}
