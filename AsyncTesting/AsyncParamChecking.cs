using System;
using System.Threading.Tasks;

namespace AsyncTesting
{
    public static class AsyncParamChecking
    {
        public static async Task TestAsyncParameters()
        {
            Task<int> task = ComputeLengthAsync(null);

            Console.WriteLine("Fetched the task");
            int length = await task;

            Console.WriteLine("Length: {0}", length);
        }

        static async Task<int> ComputeLengthAsync(string text)
        {
            if (text == null)
            {
                throw new ArgumentNullException("text");
            }
            await Task.Delay(500);
            return text.Length;
        }

        // Fixed version 
        public static Task<int> BetterComputeLengthAsync(string text)
        {
            if (text == null)
            {
                throw new ArgumentNullException("text");
            }
            return ComputeLengthAsyncImpl(text);
        }

        static async Task<int> ComputeLengthAsyncImpl(string text)
        {
            await Task.Delay(500); // Simulate real asynchronous work return text.Length; } 
            return text.Length;
        }

    }
}
 