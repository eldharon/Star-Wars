using System;
using System.Reflection;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Microsoft.Owin;
using Owin;
using Star_Wars.DAL;
using Star_Wars.Model;
using Star_Wars.Repository;
using Star_Wars.Service;


[assembly: OwinStartup(typeof(Star_Wars.App_Start.Startup))]

namespace Star_Wars.App_Start
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            WebApiConfig.Register(GlobalConfiguration.Configuration);

            //Instance of Dependency Injection
            StructuremapWebApi.Start();
        }       
    }
}
