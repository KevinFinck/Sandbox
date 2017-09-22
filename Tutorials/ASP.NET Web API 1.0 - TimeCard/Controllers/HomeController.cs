using System.Web.Mvc;

namespace Tutorial.WebApi.TimeKeeper.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
    }
}
