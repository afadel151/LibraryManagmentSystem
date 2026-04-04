using Borrowing.Web.Components;
using Radzen;
using Borrowing.Web.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddRazorComponents()
                .AddInteractiveServerComponents();
                
builder.Services.AddRadzenComponents();

var apiBase = builder.Configuration["ApiSettings:BaseAddress"]
              ?? throw new InvalidOperationException("ApiSettings:BaseAddress is not configured.");

builder.Services.AddBorrowingApiServices(apiBase);
builder.Services.Configure<Microsoft.AspNetCore.Components.Server.CircuitOptions>(options =>
{
    // no prerender config here — it's controlled per-component
});
var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    app.UseHsts();
}

app.UseAntiforgery();



app.MapStaticAssets();
app.MapRazorComponents<App>().AddInteractiveServerRenderMode();

app.Run();