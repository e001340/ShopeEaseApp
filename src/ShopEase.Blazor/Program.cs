using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using ShopEase.Blazor;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

//builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri("http://localhost:5233/") });
 builder.Services.AddScoped<ShopEase.Blazor.Services.ApiService>();
 builder.Services.AddScoped<ShopEase.Blazor.Services.ApiService>(sp =>
     new ShopEase.Blazor.Services.ApiService(
         sp.GetRequiredService<HttpClient>(),
         sp.GetRequiredService<Microsoft.JSInterop.IJSRuntime>()
     )
 );
 builder.Services.AddScoped<ShopEase.Blazor.Services.AuthService>();

await builder.Build().RunAsync();
