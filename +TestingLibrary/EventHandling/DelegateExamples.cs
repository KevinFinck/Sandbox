using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestingLibrary.EventHandling
{
    public class DelegateExamples
    {

        public delegate int Calculate(int x, int y);

        public void Process(int x, int y, Calculate calculateFunction)
        {
            Console.WriteLine("Calculating . . .");
            var result = calculateFunction(x, y);
            Console.WriteLine($"Result is {result}.");
        }

        public int BigCalculator(int x, int y)
        {
            Console.WriteLine("I'm calculating...");
            return x * y;
        }

        private void ProcessMessages(Action<string> myActionHandler, string message)
        {
            myActionHandler(message);
        }

        private void ShowMe(string value)
        {
            Console.WriteLine($"Show me says: {value}.");
        }

        public void TestMe()
        {
            Process(1, 2, (x, y) => x + y);
            Process(3, 4, BigCalculator);

            ProcessMessages(Console.WriteLine, "console");
            ProcessMessages(ShowMe, "show me");
        }
    }
}
