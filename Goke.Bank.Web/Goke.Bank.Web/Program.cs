using Goke.Bank.Web.Components;
using Goke.Bank.Web.Components.Account;
using Goke.Core.Services;
using Microsoft.AspNetCore.Authentication.Cookies;

var builder = WebApplication.CreateBuilder(args);

builder.AddServiceDefaults();

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents()
    .AddInteractiveWebAssemblyComponents();

//+authentication
// Add authentication and authorization services
builder.Services.AddCascadingAuthenticationState();
builder.Services.AddAuthorization();
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(options =>
    {
        options.LoginPath = "/login";
        options.AccessDeniedPath = "/access-denied";
    });

//
builder.Services.AddHttpContextAccessor();

// Add configuration for the backend API options
builder.Services.Configure<BackendApiOptions>(builder.Configuration.GetSection(BackendApiOptions.SectionName));
builder.Services.AddSingleton<BackendApiEndpoints>();

// Add httpclient service for API calls
builder.Services.AddHttpClient(BackendApiEndpoints.ClientName, (sp, client) => {
    var endpoint = sp.GetRequiredService<BackendApiEndpoints>();
    client.BaseAddress = endpoint.BaseUri ?? throw new InvalidOperationException("API base URL is not configured");
})
.ConfigurePrimaryHttpMessageHandler(() => new HttpClientHandler());

// Add httpclient service for API calls
//builder.Services.AddHttpClient("BackendApi", client =>
//client.BaseAddress = new Uri(builder.Configuration["Backend:BaseUrl"] ?? throw new InvalidOperationException("API base URL is not configured")));

builder.Services.AddHttpClient<AuthApiClient>((sp, client) => {
    var endpoint = sp.GetRequiredService<BackendApiEndpoints>();
    client.BaseAddress = endpoint.BaseUri ?? throw new InvalidOperationException("API base URL is not configured");
});
//-authentication


var app = builder.Build();

app.MapDefaultEndpoints();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseWebAssemblyDebugging();
}
else
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}
app.UseStatusCodePagesWithReExecute("/not-found", createScopeForStatusCodePages: true);
app.UseHttpsRedirection();

//+authentication
app.UseAuthentication();
app.UseAuthorization();
//-authentication

app.UseAntiforgery();

app.MapStaticAssets();
app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode()
    .AddInteractiveWebAssemblyRenderMode()
    .AddAdditionalAssemblies(typeof(Goke.Bank.Web.Client._Imports).Assembly);

//+authentication
app.MapAccountEndpoints();
//-authentication

app.Run();
