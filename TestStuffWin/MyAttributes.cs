using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestStuffWin
{
    public class MyAttribute : Attribute
    {
        public bool IsTransaction { get; set; } = false;
    }

    public class ReflectionTest
    {
        [MyAttribute]
        public void LookAtMe()
        {
        }

        [MyAttribute(IsTransaction = true)]
        public void LookAtMyTransaction()
        {
        }

        public void IgnoreMe()
        {
        }
    }
}
