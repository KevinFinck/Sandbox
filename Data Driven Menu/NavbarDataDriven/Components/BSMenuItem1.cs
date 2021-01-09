using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NavbarDataDriven
{
  public class BSMenuItem1
  {
    public string Title { get; set; }
    public string Action { get; set; }

    public override string ToString()
    {
      return Title;
    }
  }
}