using GlosApp.Client;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.Logging;

var builder = WebAssemblyHostBuilder.CreateDefault(args);

// Ställ in loggnivå och använd standardlogger
builder.Logging.SetMinimumLevel(LogLevel.Information); // Eller LogLevel.Debug för mer detaljerad loggning

builder.Services.AddScoped<HttpClient>(sp =>
    new HttpClient { BaseAddress = new Uri("https://api.openai.com/") });

builder.Services.AddAuthorizationCore();
builder.Services.AddCascadingAuthenticationState();
builder.Services.AddSingleton<AuthenticationStateProvider, PersistentAuthenticationStateProvider>();

var host = builder.Build();

// Logga att appen har startat
var logger = host.Services.GetRequiredService<ILogger<Program>>();
logger.LogInformation("?? Blazor WebAssembly har startats!");

await host.RunAsync();
