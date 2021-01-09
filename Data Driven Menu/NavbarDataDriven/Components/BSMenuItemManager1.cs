using System.Collections.Generic;

namespace NavbarDataDriven
{
  public class BSMenuItemManager1
  {
    public BSMenuItemManager1()
    {
      Menus = new List<BSMenuItem1>();
    }

    public List<BSMenuItem1> Menus { get; set; }

    public void Load()
    {
      BSMenuItem1 entity = new BSMenuItem1();

      entity.Title = "Home";
      entity.Action = "/Home/Home";
      Menus.Add(entity);

      entity = new BSMenuItem1();
      entity.Title = "Maintenance";
      entity.Action = "/Maintenance/Maintenance";
      Menus.Add(entity);

      entity = new BSMenuItem1();
      entity.Title = "Reports";
      entity.Action = "/Reports/Reports";
      Menus.Add(entity);

      entity = new BSMenuItem1();
      entity.Title = "Lookup";
      entity.Action = "/Lookup/Lookup";
      Menus.Add(entity);
    }
  }
}