using Infrastructure.Engine;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace SmartStore.Manager.Api
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
           // EngineContext.Current.InitializeContainer();
            AutoMapperProvider.Init();
           // IoCContainer ioc = new IoCContainer(EngineContext.Current.ContainerManager.Container);
           // GlobalConfiguration.Configuration.DependencyResolver = ioc;
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }
    }
}
