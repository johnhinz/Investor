﻿using System.Web.Http;
using Investor.Common.Shared.IoC;
using Microsoft.Practices.Unity;
using Investor.Common.Service.Investment.Data;
using Investor.Common.Service.Investment.Logic;
using Investor.Common.Shared.Interfaces;

namespace Investor.Common.Service.Investment.Api
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
            container.RegisterType<IInvestmentRepository, InvestmentRepository>(new HierarchicalLifetimeManager());
            container.RegisterType<IInvestmentLogic, InvestmentLogic>(new HierarchicalLifetimeManager());

            config.DependencyResolver = new UnityResolver(container);

            config.Formatters.JsonFormatter.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;

            config.EnableCors();
        }
    }
}
