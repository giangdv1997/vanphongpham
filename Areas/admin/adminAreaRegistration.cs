using System.Web.Mvc;

namespace Nhom1_VanPhongPham.Areas.admin
{
    public class adminAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "admin";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "admin_default",
                "Admin/{controller}/{action}/{id}",
                new { action = "Index", controller = "TaiKhoans", id = UrlParameter.Optional }
            );
        }
    }
}