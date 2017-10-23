using Microsoft.Owin.Hosting;
using System;
using System.Net.Http;
using System.Net.Http.Headers;

namespace SelfHostWebApi
{
    public class Program
    {
        static void Main()
        {
            string baseAddress = "http://localhost:9000/";

            // Start OWIN host 
            using (WebApp.Start<Startup>(url: baseAddress))
            {
                // Create HttpCient and make a request to api/values 
                HttpClient client = new HttpClient();
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                var response = client.GetAsync(baseAddress + "api/Test/Ping").Result;
                Console.ReadLine();
            }
        }
    }
}