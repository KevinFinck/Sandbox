using System.Net.Http;
using System.Threading.Tasks;

namespace MyWebApi2Consumer
{
    public class ApiService
    {
        public static async Task<string[]> GetValues()
        {
            return await RunAsync<string[]>("api/values");
        }

        public static async Task<string[]> GetBooks()
        {
            return await RunAsync<string[]>("api/books");
        }

        private static async Task<T> RunAsync<T>(string apiCommand)
        {
            using (var client = new ApiClient())
            {
                var response = await client.GetAsync(apiCommand);
                if (response.IsSuccessStatusCode)
                {
                    await Delay(2000);
                    return await response.Content.ReadAsAsync<T>();
                }
            }
            return default(T);
        }

        public static Task Delay(double milliseconds)
        {
            var tcs = new TaskCompletionSource<bool>();
            System.Timers.Timer timer = new System.Timers.Timer();
            timer.Elapsed += (obj, args) =>
            {
                tcs.TrySetResult(true);
            };
            timer.Interval = milliseconds;
            timer.AutoReset = false;
            timer.Start();
            return tcs.Task;
        }
    }
}
