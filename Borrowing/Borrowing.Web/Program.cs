using Borrowing.Web.Components;
using Radzen;
using Borrowing.Web.Services;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddRazorComponents()
                    .AddInteractiveServerComponents();
builder.Services.AddRadzenComponents();

builder.Services.AddHttpClient<IPretService, PretService>(client =>
{
    client.BaseAddress = new Uri("http://localhost:5026/");
});

builder.Services.AddHttpClient<IAdherentService, AdherentService>(client =>
{
    client.BaseAddress = new Uri("http://localhost:5026/");
});
var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    app.UseHsts();
}
app.UseStatusCodePagesWithReExecute("/not-found", createScopeForStatusCodePages: true);
// app.UseHttpsRedirection();

app.UseAntiforgery();

app.MapStaticAssets();
app.MapRazorComponents<App>().AddInteractiveServerRenderMode();

app.Run();
