using System;

namespace SOLID
{
    class LiskovSubstitution_Original
    {

        public void LiskovPrincipleTest()
        {
            Console.WriteLine("BadBase: " + new BadBase().Get());
            Console.WriteLine("BadSubBase: " + new BadSubClass().Get());
            Console.WriteLine("BadSubClass: " + Get(new BadSubClass()));
            Console.WriteLine("BetterSubClass: " + new BetterSubClass().Get());
        }


        // Instead of this...

        public class BadBase
        {
            public virtual object Get()
            {
                return new { Name = "BadBase" };
            }
        }

        public class BadSubClass : BadBase
        {
            public override object Get()
            {
                return "Sub with " + (base.Get() as dynamic).Name;
            }
        }

        // ...which will make this break...

        public string Get(BadBase param)
        {
            //return (param as dynamic).Name;
            return "ERROR: Endless recursion";
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
                return "Sub with " + BaseGet();
            }
        }


    }
}
