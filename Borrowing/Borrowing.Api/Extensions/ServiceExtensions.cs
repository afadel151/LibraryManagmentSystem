using Borrowing.Api.Repositories;
using Borrowing.Api.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Borrowing.Api.Extensions;

public static class ServiceExtensions
{
    public static IServiceCollection AddBorrowingServices(this IServiceCollection services)
    {
        // Repositories
        services.AddScoped(typeof(IBaseRepository<>), typeof(BaseRepository<>));
        services.AddScoped<IAdherentRepository, AdherentRepository>();
        services.AddScoped<ICategorieRepository, CategorieRepository>();
        services.AddScoped<IEtatAdherentRepository, EtatAdherentRepository>();
        services.AddScoped<IEtatExemplaireRepository, EtatExemplaireRepository>();
        services.AddScoped<IExemplairesRepository, ExemplairesRepository>();
        services.AddScoped<IHistoriquePenaliteAdherentRepository, HistoriquePenaliteAdherentRepository>();
        services.AddScoped<IHistoriquePretRepository, HistoriquePretRepository>();
        services.AddScoped<IJoursFeriesRepository, JoursFeriesRepository>();
        services.AddScoped<INoticesRepository, NoticesRepository>();
        services.AddScoped<IPenaliteAdherentRepository, PenaliteAdherentRepository>();
        services.AddScoped<IPenaliteAdherentTempRepository, PenaliteAdherentTempRepository>();
        services.AddScoped<IPenaliteRepository, PenaliteRepository>();
        services.AddScoped<IPositionRepository, PositionRepository>();
        services.AddScoped<IPretRepository, PretRepository>();
        services.AddScoped<IReservationRepository, ReservationRepository>();
        services.AddScoped<IJoursFeriesRepository, JoursFeriesRepository>();

        // Services
        services.AddScoped<IAdherentService, AdherentService>();
        services.AddScoped<ICategorieService, CategorieService>();
        services.AddScoped<INoticeService, NoticeService>();
        services.AddScoped<IPenaliteAdherentService, PenaltieAdherentService>();
        services.AddScoped<IPenaliteService, PenaltieService>();
        services.AddScoped<IPretService, PretService>();
        services.AddScoped<IRelanceService, RelanceService>();
        services.AddScoped<IReservationService, ReservationService>();
        services.AddScoped<IRestitutionService, RestitutionService>();
        services.AddScoped<IPositionService, PositionService>();
        services.AddScoped<IJoursFeriesService, JoursFeriesService>();


        return services;
    }
}
