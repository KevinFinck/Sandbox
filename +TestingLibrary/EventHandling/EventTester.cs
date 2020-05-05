using System;
using System.Runtime.CompilerServices;

namespace TestingLibrary.EventHandling
{
    public class EventTester
    {

        public delegate string DoSomeWorkHandler(int duration);

        public event DoSomeWorkHandler DoSomeWork;

        private DoSomeWorkHandler _doSomeCustomWork;
        public event DoSomeWorkHandler DoSomeCustomWork
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            add
            {
                _doSomeCustomWork = (DoSomeWorkHandler) Delegate.Combine(_doSomeCustomWork, value);
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            remove
            {
                _doSomeCustomWork = (DoSomeWorkHandler)Delegate.Remove(_doSomeCustomWork, value);
            }
        }


        #region Handlers
        private string ILikeToWork(int numberOfMinutes)
        {
            Console.WriteLine($"I'm working for {numberOfMinutes} minutes.");
            return "Work is fun!";
        }

        private string IHateWork(int numberOfMinutes)
        {
            Console.WriteLine($"This sucks, but I have to work for {numberOfMinutes} minutes.");
            return "Work sucks";
        }

        private string Meh(int minutes)
        {
            Console.WriteLine($"Same ol' for {minutes} minutes.");
            return "Work is . . . meh.";
        }
        #endregion

        private string StartWork(DoSomeWorkHandler workHandler, int minutes)
        {
            return workHandler(minutes);
        }

        public void TestMe()
        {
            var workHandler = new DoSomeWorkHandler(ILikeToWork);
            workHandler += IHateWork; // + Meh;
            workHandler += Meh;

            workHandler(1);
            Console.WriteLine();

            Console.WriteLine($"Work handler (last one wins): {StartWork(workHandler, 2)}{Environment.NewLine}");
            Console.WriteLine($"IHateWork: {StartWork(IHateWork, 3)}{Environment.NewLine}");
            Console.WriteLine($"Meh: {StartWork(IHateWork, 4)}{Environment.NewLine}");
        }

        public void TestMyWorker()
        {
            Console.WriteLine($"{Environment.NewLine}==========================================={Environment.NewLine}");
            var worker = new Worker();
            worker.WorkPerformedEvent += (sender, args) =>
            {
                Console.WriteLine($"We've done {args.HoursWorked} hour(s) of work.");
            };
            worker.WorkCompletedEvent += (sender, args) => Console.WriteLine("All done!");
            worker.DoWork(5);
        }
    }
}
