using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using BlazorBankApp;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Net.Http;
using System.Threading.Tasks;
using BlazorBankApp.Services;
//The Program class defines the application's starting point.
public class Program
{
    public static async Task Main(string[] args)
    {
        //test123
        var builder = WebAssemblyHostBuilder.CreateDefault(args);
        builder.RootComponents.Add<App>("#app");
        builder.RootComponents.Add<HeadOutlet>("head::after");

        builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

        // Register the Controller Services with the Dependency Injection container to be used in the Razor components
        builder.Services.AddScoped<BankService>();
        builder.Services.AddSingleton<AccountService>();
        builder.Services.AddSingleton<UserSessionService>();

        await builder.Build().RunAsync();
    }
}
