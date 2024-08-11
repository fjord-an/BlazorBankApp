using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using BlazorBankApp;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Net.Http;
using System.Threading.Tasks;
using BlazorBankApp.Models;
using BlazorBankApp.Services;
//The Program class defines the application's starting point.
public class Program
{
    public static async Task Main(string[] args)
    {
        var builder = WebAssemblyHostBuilder.CreateDefault(args);
        builder.RootComponents.Add<App>("#app");
        builder.RootComponents.Add<HeadOutlet>("head::after");

        builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

        // TODO elaborate on the scopes;
        // TODO (*BUG) change the scope for the balance to change when user logs out
        // Register the Controller Services with the Dependency Injection container to be used in the Razor components
        // This injects these objects into the Razor components and scoping their lifetime to the entire current session (singleton)
        // The singleton object will be destroyed when the session ends, and the scoped object will be destroyed when the component
        // is destroyed
        builder.Services.AddScoped<EverydayAccount>();
        builder.Services.AddScoped<SavingsAccount>();
        //TODO explain the service provider injection with finer details
        //The BankAccountService is injected with the EverydayAccount and SavingsAccount objects. It uses Service Injection to
        //inject the EverydayAccount and SavingsAccount objects into the BankAccountService constructor. This allows the BankAccountService
        //to access the EverydayAccount and SavingsAccount objects and their properties and methods.
        builder.Services.AddScoped<BankAccountService>(sp => new BankAccountService(
            sp.GetRequiredService<EverydayAccount>(),
            sp.GetRequiredService<SavingsAccount>()
        ));
        builder.Services.AddSingleton<AccountService>();
        builder.Services.AddSingleton<UserSessionService>();

        await builder.Build().RunAsync();
    }
}
