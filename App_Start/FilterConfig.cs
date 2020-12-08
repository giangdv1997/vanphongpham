using System.Web;
using System.Web.Mvc;

namespace Nhom1_VanPhongPham
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
