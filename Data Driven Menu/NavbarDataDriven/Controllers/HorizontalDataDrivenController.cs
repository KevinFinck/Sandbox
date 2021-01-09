using System.Web.Mvc;

namespace NavbarDataDriven.Controllers
{
  public class HorizontalDataDrivenController : Controller
  {
    public ActionResult DataDriven01()
    {
      BSMenuItemManager1 mgr =
        new BSMenuItemManager1();

      mgr.Load();

      return View(mgr);
    }

    public ActionResult DataDriven02()
    {
      BSMenuItemManager mgr =
        new BSMenuItemManager();

      mgr.Load(Server.MapPath("/Xml/Menus.xml"));

      return View(mgr);
    }
  }
}