using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestingLibrary.Linq
{
    class Builder
    {
        public IEnumerable<int> BuildIntegerSequence()
        {
            return Enumerable
                .Range(0, 10)
                .Select(i => 5 + (i * 10));
        }

        public IEnumerable<string> BuildStringSequence()
        {
            return Enumerable
                .Range(0, 10)
                .Select(i => ((char) ('A' + i)).ToString());
        }

        public void TestMe()
        {
            foreach (var num in BuildIntegerSequence())
            {
                Console.Write($"{num} : ");
            }
            Console.WriteLine();
        }
    }
}
