using Borrowing.Worker.Repositories;

namespace Borrowing.Worker.Extensions;

public static class ServiceExtensions
{
    public static IServiceCollection AddWorkerServices(this IServiceCollection services)
    {
        // Repositories
        services.AddScoped(typeof(BaseRepository<>));
        services.AddScoped< AdherentRepository>();
        services.AddScoped< CategorieRepository>();

        services.AddScoped< ExemplairesRepository>();
        services.AddScoped< HistoriquePenaliteAdherentRepository>();

        services.AddScoped< JoursFeriesRepository>();

        services.AddScoped< PenaliteAdherentRepository>();
        services.AddScoped< PenaliteRepository>();
        services.AddScoped< PretRepository>();
        services.AddScoped< ReservationRepository>();
        services.AddScoped< JoursFeriesRepository>();

        // Services


        return services;
    }
}
