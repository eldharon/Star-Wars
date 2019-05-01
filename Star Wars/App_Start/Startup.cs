using System;
using System.Reflection;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Autofac;
using Autofac.Integration.Mvc;
using Microsoft.Owin;
using Owin;
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
            ConfigureContainer();
        }

        private void ConfigureContainer()
        {
            var builder = new ContainerBuilder();

            //automatyczna rejestracja wszystkich kontrolerów
            builder.RegisterControllers(Assembly.GetExecutingAssembly());
            builder.RegisterAssemblyModules(Assembly.GetExecutingAssembly());

            builder.RegisterType<Repository<Character>>().As<IRepository<Character>>();
            builder.RegisterType<Repository<Episode>>().As<IRepository<Episode>>();


            builder.RegisterType<Service<Character>>().As<IService<Character>>();
            builder.RegisterType<Service<Episode>>().As<IService<Episode>>();

            var container = builder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
        }
    }
}
