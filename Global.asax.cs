using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace AddRawUrlToApplicationInsights
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }

        protected void Application_BeginRequest(object sender, EventArgs e)
        {
            string fullOrigionalpath = Request.Url.ToString();
            if (fullOrigionalpath.Contains("/about"))
            {
                Context.RewritePath("/home/about");
            }
            else if(fullOrigionalpath.Contains("/contact"))
            {
                Context.RewritePath("/home/contact");
            }
        }
    }
}
