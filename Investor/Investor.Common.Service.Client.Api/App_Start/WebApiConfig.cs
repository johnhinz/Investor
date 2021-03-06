﻿using System.Web.Http;
using Microsoft.Practices.Unity;
using Microsoft.Owin;
using Investor.Common.Shared.IoC;
using Investor.Common.Service.Client.Data;
using Investor.Common.Service.Client.Logic;
using Investor.Common.Shared.Interfaces;
using log4net;
using System.Reflection;
using Investor.Common.Shared.Authentication;

//[assembly: OwinStartup(typeof(Investor.Common.Shared.OAuth.Startup))]

namespace Investor.Common.Service.Client.Api
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api.invest.com/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            // IoC Injection setup
            var container = new UnityContainer();
            container.RegisterType<IClientRepository, ClientRepository>(new HierarchicalLifetimeManager());
            container.RegisterType<IClientLogic, ClientLogic>(new HierarchicalLifetimeManager());
            container.RegisterType<ILog>(new InjectionFactory(x => LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType)));
            container.RegisterType<IAuthenticationRepository, AuthenticationRepository>(new HierarchicalLifetimeManager());
            config.DependencyResolver = new UnityResolver(container);

            // JSON serialize settings
            config.Formatters.JsonFormatter.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;

            // CORS setup
            config.EnableCors();

            // Authentication filters
            config.Filters.Add(new BasicAuthenticationFilter());

            //config.SuppressDefaultHostAuthentication();
            //config.Filters.Add(new HostAuthenticationFilter(OAuthDefaults.AuthenticationType));
        }
    }
}
