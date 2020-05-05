using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestingLibrary.ServiceLocator
{
    public interface IMyService
    {
        void DoStuff();
    }
    public class MyService : IMyService
    {
        public void DoStuff()
        {
            Console.WriteLine("I did stuff.");
        }
    }
    public class MyServiceToo : IMyService
    {
        public void DoStuff()
        {
            Console.WriteLine("I did stuff too.");
        }
    }
}
