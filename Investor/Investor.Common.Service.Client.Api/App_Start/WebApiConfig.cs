using System.Web.Http;

using Microsoft.Practices.Unity;
using Microsoft.Owin;



using Investor.Common.Shared.IoC;
using Investor.Common.Service.Client.Data;
using Investor.Common.Service.Client.Logic;
using Investor.Common.Shared.Interfaces;
//using Investor.Common.Shared.OAuth;


[assembly: OwinStartup(typeof(Investor.Common.Shared.OAuth.Startup))]

namespace Investor.Common.Service.Client.Api
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API routes
            config.MapHttpAttributeRoutes();

            var container = new UnityContainer();
            container.RegisterType<IClientRepository, ClientRepository>(new HierarchicalLifetimeManager());
            container.RegisterType<IClientLogic, ClientLogic>(new HierarchicalLifetimeManager());

            config.DependencyResolver = new UnityResolver(container);

            config.Formatters.JsonFormatter.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;

            config.EnableCors();

            //config.SuppressDefaultHostAuthentication();
            //config.Filters.Add(new HostAuthenticationFilter(OAuthDefaults.AuthenticationType));
        }
    }
}
