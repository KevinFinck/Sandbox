using System.Web.Mvc;

namespace Tutorial.WebApi.TimeKeeper
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}