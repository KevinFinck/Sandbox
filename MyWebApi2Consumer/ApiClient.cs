using System;
using System.Net.Http;
using System.Net.Http.Headers;

namespace MyWebApi2Consumer
{
    public class ApiClient : HttpClient
    {
        public ApiClient()
        {
            BaseAddress = new Uri("http://localhost:52822/");
            DefaultRequestHeaders.Accept.Clear();
            DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }
    }
}