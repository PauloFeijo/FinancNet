using Blazored.LocalStorage;
using FinancNetWeb;
using FinancNetWeb.Services.Api;
using FinancNetWeb.Services.Auth;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddHttpClient("FinancNet", options =>
{
    options.BaseAddress = new Uri("https://localhost:5001/");
}).AddHttpMessageHandler<CustomHttpHandler>();

builder.Services
    .AddBlazoredLocalStorage()
    .AddAuthorizationCore()
    .AddScoped<AuthenticationStateProvider, ApiAuthenticationStateProvider>()
    .AddScoped<IAuthService, AuthService>()
    .AddScoped<CustomHttpHandler>()
    .AddScoped<IAccountService, AccountService>();

await builder.Build().RunAsync();
