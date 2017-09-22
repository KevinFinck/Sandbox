using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace AsyncTesting
{
    public class AsyncIt
    {
        // Async Method
        public static async Task<int> GetPageLengthAsync(string url)
        {
            using (HttpClient client = new HttpClient())
            {
                Task<string> fetchTextTask = 
                    client.GetStringAsync(url);    // Asynchronous Operation

                int length = (await fetchTextTask).Length;
                return length;
            }
        }

        // Get it Now.
        public static int GetPageLengthAsyncNow(string url)
        {
            var task = GetPageLengthAsync(url);
            task.Wait();
            return task.Result;
        }

        // Calling Method
        public static async void PrintPageLength(string url)
        {
            Task<int> lengthTask = GetPageLengthAsync(url);

            // From the book:   
            //      Console.WriteLine(lengthTask.Result); 

            #region Answer
            Console.WriteLine($"Page length: {await lengthTask}");
            #endregion
        }

    }
}
