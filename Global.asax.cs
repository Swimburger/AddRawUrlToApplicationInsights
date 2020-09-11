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
            // This code snippet is for demo purposes only!
            // these types of rewrites can be performed by IIS Rewrite module 
            // or you can update the routing table to resolve '/' to the HomeController
            
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
