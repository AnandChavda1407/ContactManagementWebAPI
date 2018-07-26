using ContactInfoManagement.DAL;
using ContactInfoManagement.Entities.Interfaces;
using ContactInfoManagement.WebAPI.App_Start;
using ContactInfoManagement.WebAPI.Models;
using System.Net.Http.Headers;
using System.Web.Http;
using Unity;
using Unity.Lifetime;

namespace ContactInfoManagement.WebAPI
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services
            var container = new UnityContainer();
            container.RegisterType<IContactRepository, ContactInfoRepository>(new HierarchicalLifetimeManager());
            config.DependencyResolver = new UnityResolver(container);
            // Web API routes
            config.MapHttpAttributeRoutes();
            config.Formatters.JsonFormatter.SupportedMediaTypes.Add(new MediaTypeHeaderValue("application/json"));
            config.Formatters.Remove(config.Formatters.XmlFormatter);
            config.Filters.Add(new CustomExceptionFilter());
            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}
