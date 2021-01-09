using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;

namespace NavbarDataDriven
{
  public class BSMenuItemManager
  {
    public List<BSMenuItem> Menus { get; set; }

    public List<BSMenuItem> Load(string location)
    {
      XElement menus = XElement.Load(location);

      Menus = LoadMenus(menus, 0);

      return Menus;
    }

    private List<BSMenuItem> LoadMenus(XElement menus,
                                         int ParentId)
    {
      List<BSMenuItem> nodes = new List<BSMenuItem>();

      nodes =
        (from node in menus.Elements("Menu")
         where node.Element("ParentId").GetAs<int>()
               == ParentId
         orderby node.Element("DisplayOrder").GetAs<int>()
         select new BSMenuItem
         {
           MenuId = node.Element("MenuId").GetAs<int>(),
           ParentId = node.Element("ParentId").GetAs<int>(),
           Title = node.Element("Title").Value,
           DisplayOrder =
             node.Element("DisplayOrder").GetAs<int>(),
           Action = node.Element("Action").Value,
           Menus =
             (ParentId != node.Element("MenuId").GetAs<int>() ?
             LoadMenus(menus, node.Element("MenuId").GetAs<int>()) :
             new List<BSMenuItem>())
         }).ToList();

      return nodes;
    }
  }
}