using System.Web.Mvc;
using System.Web.Routing;

namespace MyPortal
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            // Default route pointing to the Home controller's Index action
            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "homepage", id = UrlParameter.Optional }
            );

            // Route for Homepage (if needed)
            routes.MapRoute(
               name: "homepage",
               url: "{controller}/{action}/{id}",
               defaults: new { controller = "Account", action = "Login", id = UrlParameter.Optional }
            );

            // Route for the Dashboard (separate route for dashboard access)
            routes.MapRoute(
                 name: "Dashboard",  // Use a unique name for the Dashboard route
                 url: "dashboard/{action}/{id}",
                 defaults: new { controller = "Dashboard", action = "Index", id = UrlParameter.Optional }
             );
            routes.MapRoute(
                name: "Admin",
                url: "Dashboard/Admin",
                defaults: new { controller = "Dashboard", action = "Admin" }
             );
            routes.MapRoute(
                name: "Apply",
                url: "Dashboard/Admin",
                defaults: new { controller = "Dashboard", action = "Apply" }
             );

        }
    }
}
