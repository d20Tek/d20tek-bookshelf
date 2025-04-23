using Blazored.LocalStorage;
using D20Tek.Bookshelf.Web.Features.Books;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

namespace D20Tek.Bookshelf.Web;

public static class DependencyInjection
{
    private const string _authConfigSection = "Auth0";
    private const string _authResponseType = "code";
    private const string _authAudience = "audience";
    private const string _authAudienceConfig = "Auth0:Audience";
    private const string _serviceTestSleepDelay = "TestSleepDelay";

    public static WebAssemblyHostBuilder AddBlazorRoot(this WebAssemblyHostBuilder builder)
    {
        builder.RootComponents.Add<App>("#app");
        builder.RootComponents.Add<HeadOutlet>("head::after");

        return builder;
    }

    public static WebAssemblyHostBuilder AddPresentationServices(this WebAssemblyHostBuilder builder) =>
        builder.AddHttpClient()
               .AddOicdAuth()
               .AddServices();

    private static WebAssemblyHostBuilder AddHttpClient(this WebAssemblyHostBuilder builder)
    {
        builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
        Constants.ServiceSleepDelay = builder.Configuration.GetValue<int>(_serviceTestSleepDelay, 0);

        return builder;
    }

    private static WebAssemblyHostBuilder AddOicdAuth(this WebAssemblyHostBuilder builder)
    {
        builder.Services.AddOidcAuthentication(options =>
        {
            builder.Configuration.Bind(_authConfigSection, options.ProviderOptions);
            options.ProviderOptions.ResponseType = _authResponseType;
            options.ProviderOptions.AdditionalProviderParameters.Add(_authAudience, builder.GetAudienceConfig());
        });

        return builder;
    }

    private static string GetAudienceConfig(this WebAssemblyHostBuilder builder) =>
        builder.Configuration[_authAudienceConfig] ?? string.Empty;

    private static WebAssemblyHostBuilder AddServices(this WebAssemblyHostBuilder builder)
    {
        builder.Services.AddBlazoredLocalStorage()
                        .AddScoped<IBooksService, BooksService>();

        return builder;
    }
}
