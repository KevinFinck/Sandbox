using System;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;

namespace AsyncExceptionTest
{
    class Program
    {
        // tl;dr: 
        //  Always AWAIT async call 
        //  OR 
        //  TRY/CATCH within async method called (caller's try/catch won't help)

        /*
        This quick post is motivated by a question on StackOverflow. Basically it is a simple console program you can run to see 
        how exceptions are handled in C# async methods. Common wisdom is “don’t have async void methods; always return a Task” 
        but that simple signature change is neither necessary nor sufficient to handle exceptions correctly.

        Basically, in order to be safe you need to do one of two things:

        Handle exceptions within the async method itself; 
        OR
        Return a Task<T> and ensure that the caller attempts to get the result whilst also handling exceptions (possibly in a 
        parent stack frame)

        Failure to do either of these things will result in unwanted behaviour. Here is a simple sample to run – just 
        uncomment out the method calls one at a time to see what happens.
        */
        static void Main(string[] args)
        {
            AppDomain.CurrentDomain.UnhandledException += (s, e) => Log("*** Crash! ***", "UnhandledException");
            TaskScheduler.UnobservedTaskException += (s, e) => Log("*** Crash! ***", "UnobservedTaskException");

            RunTests();

            // Let async tasks complete...
            Thread.Sleep(500);
            GC.Collect(3, GCCollectionMode.Forced, true);

            Console.Write(@"Press any key...");
            Console.ReadKey();
        }


        private static async Task RunTests()
        {
            try
            {
                // VoidNoWait();
                // AsyncVoidAwait();
                // AsyncVoidAwaitWithTry();
                TaskNoWait();
                // TaskAwait();
                // await TaskNoWait();
                // await TaskAwait();

            }
            catch (Exception ex)
            {
                Log("Exception handled OK");
            }

            // await TaskNoWait();
            // await TaskAwait();
        }


        // Unsafe
        static void VoidNoWait()
        {
            ThrowAsync();
        }

        // Unsafe
        static async void AsyncVoidAwait()
        {
            await ThrowAsync();
        }

        // Safe
        static async void AsyncVoidAwaitWithTry()
        {
            try
            {
                await ThrowAsync();
            }
            catch (Exception ex)
            {
                Log("Exception handled OK");
            }
        }

        // Safe only if caller uses await (or Result) inside a try
        static Task TaskNoWait()
        {
            return ThrowAsync();
        }

        // Safe only if caller uses await (or Result) inside a try
        static async Task TaskAwait()
        {
            await ThrowAsync();
        }

        // Helper that sets an exception asnychronously
        static Task ThrowAsync()
        {
            var tcs = new TaskCompletionSource<Task>();
            ThreadPool.QueueUserWorkItem(_ => tcs.SetException(new Exception("ThrowAsync")));
            return tcs.Task;
        }

        internal static void Log(string message = null, [CallerMemberName] string caller = null)
        {
            if (string.IsNullOrEmpty(message))
            {
                Console.WriteLine();
            }
            else
            {
                Console.WriteLine($@"{caller}: {message}");
            }
        }
    }
}
