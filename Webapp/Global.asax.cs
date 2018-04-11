using AutoMapper;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Webapp.Models;

namespace Webapp
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            Mapper.Initialize(cfg => {
                cfg.CreateMap<Actor, ActorViewModel>().ReverseMap();
                cfg.CreateMap<Customer, CustomerViewModel>().ReverseMap();
                cfg.CreateMap<Movie, MovieViewModel>().ReverseMap();
            });
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }
    }
}
