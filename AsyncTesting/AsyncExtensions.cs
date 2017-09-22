using System;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace AsyncTesting
{
    public static class AsyncExtensions
    {
        public static AggregatedExceptionAwaitable WithAggregatedExceptions(this Task task)
        {
            return new AggregatedExceptionAwaitable(task);
        }
    }

    public class SomeCode
    {

        // Use example:
        public static async Task CatchMultipleExceptions()
        {
            Task task1 = Task.Run(() => { throw new Exception("Message 1"); });
            Task task2 = Task.Run(() => { throw new Exception("Message 2"); });

            try
            {
                await Task.WhenAll(task1, task2).WithAggregatedExceptions();
            }
            catch (AggregateException e)
            {
                Console.WriteLine(@"Caught {0} exceptions: {1}", 
                    e.InnerExceptions.Count, 
                    string.Join(", ", e.InnerExceptions.Select(x => x.Message)));
            }
        }
    }




    // Pass-through wrapper.
    public class AggregatedExceptionAwaitable
    {
        private Task _task;
        public AggregatedExceptionAwaitable(Task task)
        {
            _task = task;
        }

        public AggregatedExceptionAwaiter GetAwaiter()
        {
            return new AggregatedExceptionAwaiter(_task);
        }

    }

    public class AggregatedExceptionAwaiter : INotifyCompletion
    {
        #region Pass-through wrapper stuff.
        private Task _task;
        public AggregatedExceptionAwaiter(Task task)
        {
            _task = task;
        }

        public bool IsCompleted
        {
            get
            {
                return _task.GetAwaiter().IsCompleted;
            }
        }

        public void OnCompleted(Action continuation)
        {
            _task.GetAwaiter().OnCompleted(continuation);
        }
        #endregion

        // This OVERRIDES the normal GetResult that would return just the first Exception.
        public void GetResult()
        {
            _task.Wait();
        }
    }
}
