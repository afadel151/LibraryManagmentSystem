using Borrowing.Web.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Components.Authorization;

namespace Borrowing.Web.Extensions;

public static class ServiceExtensions
{
    public static IServiceCollection AddBorrowingApiServices(
        this IServiceCollection services,
        string baseAddress)
    {
        // Auth
        services.AddScoped<CookieAuthStateProvider>();
        services.AddScoped<AuthenticationStateProvider>(
            sp => sp.GetRequiredService<CookieAuthStateProvider>());

        services.AddAuthentication(Microsoft.AspNetCore.Authentication.Cookies.CookieAuthenticationDefaults.AuthenticationScheme)
            .AddCookie(options =>
            {
                options.LoginPath = "/Login";
            });
        services.AddAuthorizationCore();
        services.AddAuthorization();
        services.AddCascadingAuthenticationState();

        // One single HttpClient
        services.AddHttpClient("BorrowingApi", client =>
            client.BaseAddress = new Uri(baseAddress))
            .ConfigurePrimaryHttpMessageHandler(() => new HttpClientHandler
            {
                UseCookies = true,
                ServerCertificateCustomValidationCallback =
                    HttpClientHandler.DangerousAcceptAnyServerCertificateValidator
            });

        // Services — plain scoped, they get IHttpClientFactory injected
        services.AddScoped<IAdherentService,    AdherentService>();
        services.AddScoped<IPretService,        PretService>();
        services.AddScoped<INoticeService,      NoticeService>();
        services.AddScoped<IExemplaireService,  ExemplaireService>();
        services.AddScoped<IReservationService, ReservationService>();
        services.AddScoped<IRestitutionService, RestitutionService>();
        services.AddScoped<IExportService,      ExportService>();
        services.AddScoped<ICategorieService,   CategorieService>();
        services.AddScoped<IPositionService,    PositionService>();

        return services;
    }
}