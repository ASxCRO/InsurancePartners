using Autofac.Integration.Mvc;
using Autofac;
using Partners.Web.Data.Entities;
using Partners.Web.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace Partners.Web
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            // Set up Autofac
            var builder = new ContainerBuilder();

            // Register controllers
            builder.RegisterControllers(Assembly.GetExecutingAssembly());

            // Register repositories
            builder.RegisterType<PartnerRepository>().As<IPartnerRepository>();
            builder.RegisterType<PolicyRepository>().As<IRepository<Policy>>();

            var container = builder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
        }
    }
}
