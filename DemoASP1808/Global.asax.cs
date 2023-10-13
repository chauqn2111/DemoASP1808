using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Optimization;
using System.Web.Routing;
using System.Web.Security;
using System.Web.SessionState;

namespace DemoASP1808
{
    public class Global : HttpApplication
    {
        void Application_Start(object sender, EventArgs e)
        {
            // Code that runs on application startup
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

        }
    }
    public class MvcApplication : HttpApplication
    {

        private const String ReturnUrlRegexPattern = @"\?ReturnUrl=.*$";

        public MvcApplication()
        {

            PreSendRequestHeaders += MvcApplicationOnPreSendRequestHeaders;

        }

        private void MvcApplicationOnPreSendRequestHeaders(object sender, EventArgs e)
        {

            String redirectUrl = Response.RedirectLocation;

            if (String.IsNullOrEmpty(redirectUrl)
                 || !Regex.IsMatch(redirectUrl, ReturnUrlRegexPattern))
            {

                return;

            }

            Response.RedirectLocation = Regex.Replace(redirectUrl,
                                                       ReturnUrlRegexPattern,
                                                       String.Empty);

        }

    }
}