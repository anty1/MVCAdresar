using System.Web;
using System.Web.Mvc;

namespace OmegaSoftware_Adresar_kontakata
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}