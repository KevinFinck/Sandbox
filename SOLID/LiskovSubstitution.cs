using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOLID
{
    class LiskovSubstitution
    {
        /*
        public void LiskovPrincipleTest()
        {
            Console.WriteLine("BadBase: " + new BadBase().Name);
            Console.WriteLine("BadSubClass: " + new BadSubClass().Name);
            Console.WriteLine("BetterSubClass: " + new BetterSubClass().Get());
        }


        // Instead of this...

        public class BadBase
        {
            public virtual string Name { get { return "BadBase"; } }
        }

        public class BadSubClass : BadBase
        {
            public override string Name
            {
                get { return "Sub with " + base.Name; }
            }
        }

        // ...which will make this break...

        public string Get(BadBase param)
        {
            return (param as dynamic).Name;
        }

        // ...do this.

        public abstract class BetterBase
        {
            protected object BaseGet()
            {
                return new { Name = "BetterBase" };
            }

            public abstract string Get();
        }

        public class BetterSubClass : BetterBase
        {
            public override string Get()
            {
                return "Sub with" + Get().Name;
            }
        }

        */
    }
}
