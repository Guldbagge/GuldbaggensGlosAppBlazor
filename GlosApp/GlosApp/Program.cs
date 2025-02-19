using GlosApp.Client.Pages;
using GlosApp.Components;
using GlosApp.Components.Account;
using GlosApp.Data;
using GlosApp.Services;
using GlosApp.Services.Horse;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using MudBlazor.Services;

var builder = WebApplication.CreateBuilder(args);

// Hantera laddning av secrets beroende på miljön
var basePath = Directory.GetCurrentDirectory();
var isHosting = basePath.Contains("public_html");

var secretFilePath = isHosting
    ? Path.Combine(basePath, "../secrets/appsettings.secrets.json")  // För webbhotellet
    : Path.Combine("C:/Education/secrets-pluggat/appsettings.secrets.json"); // För lokalt

Console.WriteLine($"Laddar secrets från: {secretFilePath}");

if (File.Exists(secretFilePath))
{
    Console.WriteLine("? Hittade appsettings.secrets.json!");
    builder.Configuration.AddJsonFile(secretFilePath, optional: true, reloadOnChange: true);
}
else
{
    Console.WriteLine("? Hittade INTE appsettings.secrets.json!");
}


if (File.Exists(secretFilePath))
{
    builder.Configuration.AddJsonFile(secretFilePath, optional: true, reloadOnChange: true);
}

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents()
    .AddInteractiveWebAssemblyComponents();

builder.Services.AddHttpClient();
builder.Services.AddCascadingAuthenticationState();
builder.Services.AddScoped<IdentityUserAccessor>();
builder.Services.AddScoped<IdentityRedirectManager>();
builder.Services.AddScoped<AuthenticationStateProvider, PersistingRevalidatingAuthenticationStateProvider>();

builder.Services.AddScoped<HttpClient>(sp =>
    new HttpClient { BaseAddress = new Uri("https://api.openai.com/") });

builder.Services.AddAuthentication(options =>
{
    options.DefaultScheme = IdentityConstants.ApplicationScheme;
    options.DefaultSignInScheme = IdentityConstants.ExternalScheme;
})
    .AddIdentityCookies();

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection")
    ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(connectionString));
builder.Services.AddDatabaseDeveloperPageExceptionFilter();

builder.Services.AddIdentityCore<ApplicationUser>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddEntityFrameworkStores<ApplicationDbContext>()
    .AddSignInManager()
    .AddDefaultTokenProviders();

builder.Services.AddSingleton<IEmailSender<ApplicationUser>, IdentityNoOpEmailSender>();
builder.Services.AddSingleton<ConfigurationService>();
builder.Services.AddScoped<HorseDiaryService>();
builder.Services.AddScoped<HorseHealthService>();

// Add MudBlazor services diagram -- builder.Services.AddMudServices();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseWebAssemblyDebugging();
    app.UseMigrationsEndPoint();
}
else
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode()
    .AddInteractiveWebAssemblyRenderMode()
    .AddAdditionalAssemblies(typeof(GlosApp.Client._Imports).Assembly);

// Add additional endpoints required by the Identity /Account Razor components.
app.MapAdditionalIdentityEndpoints();

app.Run();
