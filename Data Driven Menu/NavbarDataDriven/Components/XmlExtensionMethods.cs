using System;
using System.Xml.Linq;

namespace NavbarDataDriven
{
  public static class XmlExtensionMethods
  {
    public static T GetAs<T>(this XElement elem, T defaultValue = default(T))
    {
      T ret = defaultValue;

      if (elem != null && !string.IsNullOrEmpty(elem.Value))
      {
        // Cast to Return Data Type 
        // NOTE: ChangeType does NOT work with Nullable Types
        ret = (T)Convert.ChangeType(elem.Value, typeof(T));
      }

      return ret;
    }
  }
}
