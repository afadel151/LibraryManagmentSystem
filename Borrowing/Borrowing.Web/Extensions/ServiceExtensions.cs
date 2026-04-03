// Services/ServiceExtensions.cs
using Borrowing.Web.Services;

namespace Borrowing.Web.Extensions;

public static class ServiceExtensions
{
    public static IServiceCollection AddBorrowingApiServices(
        this IServiceCollection services,
        string baseAddress)
    {
        services.ConfigureHttpClientDefaults(http =>
            http.ConfigureHttpClient(c => c.BaseAddress = new Uri(baseAddress)));

        services.AddHttpClient<IPretService, PretService>();
        services.AddHttpClient<IAdherentService, AdherentService>();
        services.AddHttpClient<IRestitutionService, RestitutionService>();
        services.AddHttpClient<INoticeService, NoticeService>();
        services.AddHttpClient<IExemplaireService, ExemplaireService>();
        services.AddScoped<IExportService,ExportService>();

        return services;
    }
}