using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Routing;
using System.Web.Security;
using System.Web.SessionState;

namespace YouBetterAsk
{
    public class Global : System.Web.HttpApplication
    {

        protected void Application_Start(object sender, EventArgs e)
        {
            //RouteTable.Routes.MapHttpRoute("BuzzApi_1", "api/{controller}");
            RouteTable.Routes.MapHttpRoute("BuzzApi_2", "api/{controller}/{action}/{id}", new { id = System.Web.Http.RouteParameter.Optional });
            //RouteTable.Routes.MapHttpRoute("BuzzApi_3", "api/{controller}/{action}");
            var config = GlobalConfiguration.Configuration.Formatters.XmlFormatter.SupportedMediaTypes.FirstOrDefault(t => t.MediaType == "application/xml");
            GlobalConfiguration.Configuration.Formatters.XmlFormatter.SupportedMediaTypes.Remove(config);
        }

        protected void Session_Start(object sender, EventArgs e)
        {

        }

        protected void Application_BeginRequest(object sender, EventArgs e)
        {

        }

        protected void Application_AuthenticateRequest(object sender, EventArgs e)
        {

        }

        protected void Application_Error(object sender, EventArgs e)
        {

        }

        protected void Session_End(object sender, EventArgs e)
        {

        }

        protected void Application_End(object sender, EventArgs e)
        {

        }
    }
}