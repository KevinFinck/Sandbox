using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestingLibrary
{
    public static class YieldTest
    {
        private static IEnumerable<int> GetEvenNumbers(IEnumerable<int> numbers)
        {
            var evens = new List<int>();
            foreach (int number in numbers)
            {
                Console.WriteLine($"GetEvenNumbers: Testing {number}");
                if (number % 2 == 0)
                {
                    evens.Add(number);
                }
            }

            return evens;
        }
        private static IEnumerable<int> GetEvenNumbersUsingYield(IEnumerable<int> numbers)
        {
            foreach (int number in numbers)
            {
                Console.WriteLine($"GetEvenNumbers: Testing {number}");
                if (number % 2 == 0)
                {
                    Console.WriteLine($"GetEvenNumbers: Yielding {number}");
                    yield return number;
                }
            }
        }

        static IEnumerable<int> GetTwoAndSix(IEnumerable<int> numbers)
        {
            foreach (int number in numbers)
            {
                Console.WriteLine($"GetTwoAndSix: Testing {number}");
                if (number == 2 || number == 6)
                {
                    Console.WriteLine($"GetTwoAndSix: Yielding {number}");
                    yield return number;
                }
            }
        }


        static void ProcessList(Func<IEnumerable<int>, IEnumerable<int>> numberProcessor)
        {
            var numbers = numberProcessor(Enumerable.Range(1, 10));
            foreach (var number in numbers)
            {
                Console.WriteLine($"Output: {number}");
            }
        }

        public static void TestMe()
        {
            Console.WriteLine("*****Running Without Yield *****");
            ProcessList(GetEvenNumbers);

            Console.WriteLine($"{Environment.NewLine}*****Running With Yield *****");
            ProcessList(GetEvenNumbersUsingYield);

            Console.WriteLine($"{Environment.NewLine}*****Running With Yield 2 and 6 *****");
            ProcessList(list => GetTwoAndSix(GetEvenNumbersUsingYield(list)));
        }
    }
}
