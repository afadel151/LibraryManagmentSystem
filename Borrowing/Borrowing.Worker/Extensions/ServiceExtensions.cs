using Borrowing.Worker.Repositories;
using Borrowing.Worker.Services;

namespace Borrowing.Worker.Extensions;

public static class ServiceExtensions
{
    public static IServiceCollection AddWorkerServices(this IServiceCollection services)
    {
        services.AddScoped(typeof(IBaseRepository<>), typeof(BaseRepository<>));

        services.AddScoped<IAdherentRepository, AdherentRepository>();
        services.AddScoped<ICategorieRepository, CategorieRepository>();
        services.AddScoped<IExemplairesRepository, ExemplairesRepository>();
        services.AddScoped<IHistoriquePenaliteAdherentRepository, HistoriquePenaliteAdherentRepository>();
        services.AddScoped<IJoursFeriesRepository, JoursFeriesRepository>();
        services.AddScoped<IPenaliteAdherentRepository, PenaliteAdherentRepository>();
        services.AddScoped<IPenaliteRepository, PenaliteRepository>();
        services.AddScoped<IPretRepository, PretRepository>();
        services.AddScoped<IReservationRepository, ReservationRepository>();
        services.AddScoped<IScopedPretService, ScopedPretService>();
        services.AddScoped<IScopedPenaltieService, ScopedPenaltieService>();

        return services;
    }
}