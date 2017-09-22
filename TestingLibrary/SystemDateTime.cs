using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestingLibrary
{
    public static class SystemDateTime
    {
        private static Func<DateTime> _func;

        public static void Init(Func<DateTime> func)
        {
            _func = func;
        }

        public static DateTime Now
        {
            get { return _func(); }
        }

        // Prod:   SystemDateTime.Init(() => DateTime.UtcNow);
        // Tests:  System.Init(() => new DateTime(2017, 07, 13));
    }
}
