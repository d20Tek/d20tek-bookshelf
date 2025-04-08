global using D20Tek.Functional;
global using D20Tek.Bookshelf.Web;
global using D20Tek.Bookshelf.Web.Common;
global using D20Tek.Bookshelf.Web.Domain;
global using Microsoft.AspNetCore.Components;

using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using D20Tek.Bookshelf.Web.Features.Books;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
builder.Services.AddScoped<IBooksService, BooksService>();

await builder.Build().RunAsync();
