using Business.Contracts;
using Business.Implementation;
using Data.Contracts;
using Data.Repositories;
using SimpleInjector;
using SimpleInjector.Integration.WebApi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace HeliBaja
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            var container = new SimpleInjector.Container();
            container.RegisterWebApiControllers(GlobalConfiguration.Configuration);
            //User
            container.Register<IUserService, UserService>();
            container.Register<IUserRepository, UserRepository>();

            container.Verify();
            //config.DependencyResolver = new SimpleInjectorWebApiDependecyResolver(container);
            GlobalConfiguration.Configuration.DependencyResolver =
        new SimpleInjectorWebApiDependencyResolver(container);
        }
    }
}
