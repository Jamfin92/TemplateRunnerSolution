using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace TemplateRunner
{
    public class MvcApplication : System.Web.HttpApplication
    {
        public static Logger Logger = LogManager.GetCurrentClassLogger();
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }
        
        //log unhandled exceptions
        protected void Application_Error()
        {
//using nlog, log the exception with the location of the error
            Exception ex = Server.GetLastError();
            Logger.Error(ex, "Unhandled exception");
            Response.Redirect("/Home/Error");
        }
    }
}
