using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

var builder = WebAssemblyHostBuilder.CreateDefault(args);

builder.Services.AddSingleton(sc => new HttpClient() { BaseAddress=new Uri("https://localhost:7109/") });

await builder.Build().RunAsync();
