using Fluxor;
using FluxorDemo;
using FluxorDemo.Services;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

builder.Services.AddFluxor(options =>
    options.ScanAssemblies(typeof(Program).Assembly));

builder.Services.AddScoped<TodoService>();

await builder.Build().RunAsync();
