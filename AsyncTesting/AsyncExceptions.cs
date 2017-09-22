using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace AsyncTesting
{
    class AsyncExceptions
    {
        async Task<string> FetchFirstSuccessfulAsync(IEnumerable<string> urls)
        { 
            // TODO: Validate that we've actually got some URLs... 
            foreach (string url in urls)
            {
                Task<string> task;
                try
                {
                    using (var client = new HttpClient())
                    {
                        task = client.GetStringAsync(url);    // Can be multiple operations, with multiple failures.
                        return await task;    // Can be multiple operations, with multiple failures.
                        // NOTE: The "task" does not throw an excpetion. It returns a task with IsFaulted = true.
                        // NOTE: The tasks' awaiter "GetResult" method throws the first exception, WebException.
                        // NOTE: Using .Wait() will return AggregateException.
                    }
                }
                catch (WebException exception)  // Gets FIRST of AggregateException
                {
                    // If Task were available here, it's Exception property would contain AggregateException.
                    // This method DOES lose exception information.
                    // See Listing 15.2, pg 484
                }
            }

            throw new WebException("No URLs succeeded");
        }
    }


}
