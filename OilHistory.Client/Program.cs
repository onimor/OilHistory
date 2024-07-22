using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

var builder = WebAssemblyHostBuilder.CreateDefault(args);

builder.Services.AddSingleton<OilHistory.Web.Business.OilService>();


await builder.Build().RunAsync();
