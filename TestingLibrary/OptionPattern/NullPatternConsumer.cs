using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestingLibrary.OptionPattern
{
    public class NullPatternConsumer
    {
        public Option<IPerson> FindHim(string dudesName)
        {
            return Option<IPerson>.CreateEmpty();
        }

        public string CreateCoolName(IPerson person)
        {
            return $"{person.FirstName} {person.LastName}";
        }

        public string GetSomeDudesCoolName(string someDude)
        {
            return
                FindHim(someDude)   // Option type always returns 0 or 1.
                    .Select(CreateCoolName)
                    .Single();
        }
    }
}
