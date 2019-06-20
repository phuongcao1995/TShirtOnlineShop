using System.Web.Mvc;

namespace TShirtOnlineShop.Areas.Admin
{
    public class AdminAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "Admin";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
               "Admin_default",
               "Admin/{controller}/{action}/{id}",
               new { controller = "Home", action = "signin", id = UrlParameter.Optional },
                new[] { "TShirtOnlineShop.Areas.Admin.Controllers" }
           );
        }
    }
}