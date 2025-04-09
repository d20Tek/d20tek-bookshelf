global using D20Tek.Bookshelf.Web;
global using D20Tek.Bookshelf.Web.Common;
global using D20Tek.Bookshelf.Web.Domain;
global using D20Tek.Functional;
global using Microsoft.AspNetCore.Components;

using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

var builder = WebAssemblyHostBuilder.CreateDefault(args)
                                    .AddBlazorRoot()
                                    .AddPresentationServices();

await builder.Build().RunAsync();
