using D20Tek.Bookshelf.Web.Features.Books;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

namespace D20Tek.Bookshelf.Web;

public static class DependencyInjection
{
    private const string _serviceTestSleepDelay = "TestSleepDelay";

    public static WebAssemblyHostBuilder AddBlazorRoot(this WebAssemblyHostBuilder builder)
    {
        builder.RootComponents.Add<App>("#app");
        builder.RootComponents.Add<HeadOutlet>("head::after");

        return builder;
    }

    public static WebAssemblyHostBuilder AddPresentationServices(this WebAssemblyHostBuilder builder) =>
        builder.AddHttpClient()
               .AddServices();

    private static WebAssemblyHostBuilder AddHttpClient(this WebAssemblyHostBuilder builder)
    {
        builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
        Constants.ServiceSleepDelay = builder.Configuration.GetValue<int>(_serviceTestSleepDelay, 0);

        return builder;
    }

    private static WebAssemblyHostBuilder AddServices(this WebAssemblyHostBuilder builder)
    {
        builder.Services.AddScoped<IBooksService, BooksService>();

        return builder;
    }
}
