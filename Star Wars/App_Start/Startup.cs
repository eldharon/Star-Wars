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
            ConfigureContainer();
        }

        private void ConfigureContainer()
        {
            //var container = new UnityContainer();
            //automatyczna rejestracja wszystkich kontrolerów
            //container.RegisterApiControllers(Assembly.GetExecutingAssembly());
            //container.RegisterAssemblyModules(Assembly.GetExecutingAssembly());


            //container.RegisterType<IRepository<Character>, Repository<Character>>();
            //container.RegisterType<IRepository<Episode>, Repository<Episode>>();


            //container.RegisterType<IService<Character>, Service<Character>>();
            //container.RegisterType<IService<Episode>, Service<Episode>>();

            //GlobalConfiguration.Configuration.DependencyResolver = new Unity.WebApi.UnityDependencyResolver(container);

            //var container = builder.Build();
            //DependencyResolver.SetResolver(new AutofacWebApiDependencyResolver(container));

            //var builder = new ContainerBuilder();

            // Get your HttpConfiguration.
            //var config = GlobalConfiguration.Configuration;

            //// OPTIONAL: Register the Autofac filter provider.
            //builder.RegisterWebApiFilterProvider(config);

            //// OPTIONAL: Register the Autofac model binder provider.
            //builder.RegisterWebApiModelBinderProvider();

            //// Set the dependency resolver to be Autofac.
            //var container = builder.Build();
        }
    }
}
