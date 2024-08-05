using MudBlazor;
using MudBlazor.Services;
using Blazored.LocalStorage;
using MudDemo.Client.Services;
using Toolbelt.Blazor.Extensions.DependencyInjection;


var builder = WebApplication.CreateBuilder(args);

builder.Services.AddRazorComponents().AddInteractiveServerComponents();
builder.Services.AddServerSideBlazor(); // Add server-side Blazor
builder.Services.AddRazorPages(); // Add services required for Razor Page

// Configure HttpClient with a proper BaseAddress
// Adjust the BaseAddress according to your API endpoint or environment
var httpHandler = new HttpClientHandler()
{
    AllowAutoRedirect = true,
    ServerCertificateCustomValidationCallback = (message, cert, chain, sslPolicyErrors) => true
};
builder.Services.AddSingleton(sp => new HttpClient(httpHandler)
{
    BaseAddress = new Uri("https://localhost:7227/"),
     // Set a default base URL or configure as needed
});


builder.Services.AddMudServices();



builder.Services.AddHotKeys();
builder.Services.AddBlazoredLocalStorage();
builder.Services.AddMudServices(config =>
{
    config.SnackbarConfiguration.PositionClass = Defaults.Classes.Position.BottomLeft;

    config.SnackbarConfiguration.PreventDuplicates = false;
    config.SnackbarConfiguration.NewestOnTop = false;
    config.SnackbarConfiguration.ShowCloseIcon = true;
    config.SnackbarConfiguration.VisibleStateDuration = 10000;
    config.SnackbarConfiguration.HideTransitionDuration = 500;
    config.SnackbarConfiguration.ShowTransitionDuration = 500;
    config.SnackbarConfiguration.SnackbarVariant = Variant.Filled;
});


// Register your custom services
builder.Services.AddTransient<INotificationsService, NotificationsService>();
builder.Services.AddTransient<IArticlesService, ArticlesService>();


var app = builder.Build();

// Configure the HTTP request pipeline
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();



// Map Blazor components and fallback to _Host.cshtml
app.MapBlazorHub();
app.MapFallbackToPage("/_Host"); // Ensure _Host.cshtml exists in the Pages folder

app.Run();
