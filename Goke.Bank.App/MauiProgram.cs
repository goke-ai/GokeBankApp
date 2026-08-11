using CommunityToolkit.Maui;
using Fonts;
using Goke.Bank.App.PageModels;
using Goke.Bank.App.Services;
using Goke.Core.Authorization;
using Goke.Core.Interfaces;
using Goke.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Syncfusion.Maui.Toolkit.Hosting;
using System.Reflection;

namespace Goke.Bank.App;

public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{
		var builder = MauiApp.CreateBuilder();
		builder
            .UseMauiApp<App>()
            // Initialize the .NET MAUI Community Toolkit by adding the below line of code
            .UseMauiCommunityToolkit()
            // Initialize the Syncfusion .NET MAUI Toolkit by adding the below line of code
            .ConfigureSyncfusionToolkit()
            // Maui Handlers are used to customize the behavior of controls in .NET MAUI.
            .ConfigureMauiHandlers(handlers =>
            {
#if WINDOWS
                // Customize the behavior of the CollectionView control on Windows platform
				Microsoft.Maui.Controls.Handlers.Items.CollectionViewHandler.Mapper.AppendToMapping("KeyboardAccessibleCollectionView", (handler, view) =>
				{
					handler.PlatformView.SingleSelectionFollowsFocus = false;
				});

				//Microsoft.Maui.Handlers.ContentViewHandler.Mapper.AppendToMapping(nameof(Pages.Controls.CategoryChart), (handler, view) =>
				//{
				//	if (view is Pages.Controls.CategoryChart && handler.PlatformView is Microsoft.Maui.Platform.ContentPanel contentPanel)
				//	{
				//		contentPanel.IsTabStop = true;
				//	}
				//});
#endif
            })
            // After initializing the .NET MAUI Community Toolkit, optionally add additional fonts
            .ConfigureFonts(fonts =>
            {
                fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                fonts.AddFont("SegoeUI-Semibold.ttf", "SegoeSemibold");
                fonts.AddFont("FluentSystemIcons-Regular.ttf", FluentUI.FontFamily);
            });

#if DEBUG
        builder.Logging.AddDebug();
        builder.Services.AddLogging(configure => configure.AddDebug());
#endif


        //+authentication
        // Load the embedded appsettings.json file
        var assembly = Assembly.GetExecutingAssembly();
        using var stream = assembly.GetManifestResourceStream("Goke.Bank.App.appsettings.json")
            ?? throw new InvalidOperationException("Could not find embedded resource 'Goke.Bank.App.appsettings.json'");

        builder.Configuration.AddJsonStream(stream);


        //Register needed elements for authentication:
        // This is the core functionality
        //builder.Services.AddAuthorizationCore();

        // Add configuration for the backend API options
        builder.Services.Configure<BackendApiOptions>(builder.Configuration.GetSection(BackendApiOptions.SectionName));
        builder.Services.AddSingleton<IBackendApiBaseUrlResolver, BackendApiBaseUrlResolver>();
        builder.Services.AddSingleton<BackendApiEndpoints>();

        // Add httpclient service for API calls
        builder.Services.AddHttpClient(BackendApiEndpoints.ClientName, (sp, client) => {
            var o = sp.GetRequiredService<BackendApiEndpoints>();
            client.BaseAddress = o.BaseUri ?? throw new InvalidOperationException("API base URL is not configured");
        })
        .ConfigurePrimaryHttpMessageHandler(HttpClientHelper.CreatePlatformMessageHandler);

        builder.Services.AddHttpClient<AuthApiClient>((sp, client) => {
            var endpoint = sp.GetRequiredService<BackendApiEndpoints>();
            client.BaseAddress = endpoint.BaseUri ?? throw new InvalidOperationException("API base URL is not configured");
        })
        .ConfigurePrimaryHttpMessageHandler(HttpClientHelper.CreatePlatformMessageHandler);


        // Add app services
        builder.Services.AddSingleton<TokenStorage>();
        // This is our custom provider
        // builder.Services.AddSingleton<MauiAuthenticationStateProvider>();
        // Use our custom provider when the app needs an AuthenticationStateProvider
        //builder.Services.AddScoped<AuthenticationStateProvider>(s => (MauiAuthenticationStateProvider)s.GetRequiredService<MauiAuthenticationStateProvider>());
        //builder.Services.AddSingleton<IAuthenticationService>(s => s.GetRequiredService<MauiAuthenticationStateProvider>());
        builder.Services.AddSingleton<IAuthenticationService, MauiAuthenticationStateProvider>();

        //-authentication

        // Add authorization policies
        builder.Services.AddAuthorization(options =>
        {
            options.AddPolicy("AdminOnlyPolicy", policy =>
                policy.RequireRole("Administrators"));

            options.AddPolicy("DepartmentITPolicy", policy =>
                policy.RequireClaim("Department", "IT"));

            options.AddPolicy("ProfileEditPolicy", policy =>
                policy.RequirePermission("Profile.Edit"));
        });

        
        // models
        builder.Services.AddSingleton<ModalErrorHandler>();

        // page models
        builder.Services.AddSingleton<MainPageModel>();
        builder.Services.AddSingleton<LoginPageModel>();
        builder.Services.AddSingleton<LogoutPageModel>();
        builder.Services.AddSingleton<WeatherPageModel>();
        builder.Services.AddSingleton<CounterPageModel>();

        // pages
        //builder.Services.AddTransient<MainPage>();

        return builder.Build();
	}
}
