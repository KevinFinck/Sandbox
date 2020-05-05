using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using TestingLibrary.EventHandling;

namespace TestingLibrary
{
    class Program
    {
        static void Main(string[] args)
        {
            //QuickTest();
            //BusinessId x = 5;
            //WrapperTester.TestMe(x);
            //TestEvents();
            //TestDelegates();
            //new Builder().TestMe();
            //TestCallerInfo();
            //EnumFlags.TestFlags();
            // Process.Start(Path.Combine(Environment.CurrentDirectory, "TestingLibrary.exe.config"));

            YieldTest.TestMe();

            Console.Write($"{Environment.NewLine}Press any key to exit...");
            Console.ReadKey();

        }

        private static void ReadWriteAppDataRoaming()
        {
            var appPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            //...
        }

        private static void TestCallerInfo()
        {
            Console.WriteLine(WhoCalledMe.WhoCalled());
            Console.WriteLine(WhoCalledMe.WhatFileCalled());
            Console.WriteLine(WhoCalledMe.WhatLineCalled());
        }

        private static void TestEvents()
        {
            var eventTester = new EventTester();
            eventTester.TestMe();
            eventTester.TestMyWorker();
        }

        private static void TestDelegates()
        {
            var delegateTester = new DelegateExamples();
            delegateTester.TestMe();
        }

        private static void QuickTest()
        {
            string value = null;
            Console.WriteLine("My pad: " + value.MyPadLeft(10));
            try
            {
                Console.WriteLine(".NET pad: " + value.PadLeft(10));
            }
            catch (Exception)
            {
                Console.WriteLine(".NET pad: It blew up!!");
            }

            //var fields =
            //"BAR:41440419151443309|PAN:6394250419151443309"
            //    .Split('|')
            //    .Select(data => data.Split(':'))
            //    .Where(fields => fields.Length == 2);

            foreach (
                var fields in
                    "BAR:41440419151443309|PAN:6394250419151443309"
                        .Split('|')
                        .Select(data => data.Split(':'))
                        .Where(fields => fields.Length == 2))
            {
                var x = fields[0];
                var y = fields[1];
            }
        }
    }
}
