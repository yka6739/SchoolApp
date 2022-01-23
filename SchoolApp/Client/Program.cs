using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using SchoolApp.Client.Contracts;
using SchoolApp.Client.Services;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace SchoolApp.Client
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("#app");

            builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
            builder.Services.AddBlazoredLocalStorage();
            builder.Services.AddScoped<ISchoolService, SchoolService>();
            var apiUrl = new Uri(builder.Configuration["apiUrl"]);

            void RegisterTypeClient<TClient, TImplementation>(Uri apiBaseUrl)
                where TClient : class
                where TImplementation : class,
                TClient
            {
                builder.Services.AddHttpClient<TClient, TImplementation>(client =>
                {
                    client.BaseAddress = apiBaseUrl;

                });//.AddHttpMessageHandler<ValidateHeaderHandler>();


            }
            RegisterTypeClient<IHttpService, HttpService>(apiUrl);
            await builder.Build().RunAsync();
        }
    }
}
