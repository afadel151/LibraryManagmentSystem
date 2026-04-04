using Borrowing.Web.Services;
using Borrowing.Web.Providers;
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
    
        services.AddAuthorizationCore();
        services.AddCascadingAuthenticationState();
        services.AddScoped<CookieStorageService>();
        services.AddScoped<JwtAuthStateProvider>(); 
        services.AddScoped<AuthenticationStateProvider>(
            sp => sp.GetRequiredService<JwtAuthStateProvider>());


        services.AddTransient<JwtAttachingHandler>();
        services.AddScoped<AuthService>();
        services.AddHttpContextAccessor();
        services.AddHttpClient("BorrowingApi", client =>
                client.BaseAddress = new Uri(baseAddress))
                .ConfigurePrimaryHttpMessageHandler(() => new HttpClientHandler
                {
                    ServerCertificateCustomValidationCallback =
                        HttpClientHandler.DangerousAcceptAnyServerCertificateValidator,
                }).AddHttpMessageHandler<JwtAttachingHandler>();
        services.AddScoped<ApiHttpClient>();
        services.AddScoped<AuthService>();
        services.AddScoped<IAdherentService, AdherentService>();
        services.AddScoped<IPretService, PretService>();
        services.AddScoped<INoticeService, NoticeService>();
        services.AddScoped<IExemplaireService, ExemplaireService>();
        services.AddScoped<IReservationService, ReservationService>();
        services.AddScoped<IRestitutionService, RestitutionService>();
        services.AddScoped<IExportService, ExportService>();
        services.AddScoped<ICategorieService, CategorieService>();
        services.AddScoped<IPositionService, PositionService>();
        services.AddScoped<IEtatAdherentService, EtatAdherentService>();
        return services;
    }
}