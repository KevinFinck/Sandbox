using System.Collections.Generic;

namespace NavbarDataDriven
{
  public class BSMenuItem
  {
    public BSMenuItem()
    {
      ParentId = 0;
      Menus = new List<BSMenuItem>();
    }

    public int MenuId { get; set; }
    public int ParentId { get; set; }
    public string Title { get; set; }
    public int DisplayOrder { get; set; }
    public string Action { get; set; }

    public List<BSMenuItem> Menus { get; set; }

    public override string ToString()
    {
      return Title;
    }
  }
}