
using Inventory.Repositories;
using Inventory.Services;

namespace Inventory.Extensions;

public static class ServiceExtensions
{
    public static IServiceCollection AddInventoryServices(this IServiceCollection services)
    {
        // Repositories
        services.AddScoped(typeof(IBaseRepository<>), typeof(BaseRepository<>));
        services.AddScoped<INoticeRepository, NoticeRepository>();
        services.AddScoped<IAdherentRepository, AdherentRepository>();
        services.AddScoped<ITypeNoticeRepository,TypeNoticeRepository>();
        services.AddScoped<IExemplaireRepository,ExemplaireRepository>();
        services.AddScoped<IPeriodiciteRepository,PeriodiciteRepository>();
        services.AddScoped<IFonctionRepository,FonctionRepository>();
        services.AddScoped<IPaysRepository,PaysRepository>();
        services.AddScoped<IMentionResRepository,MentionResRepository>();
        services.AddScoped<IMotsCleRepository,MotsCleRepository>();
        services.AddScoped<IEditeurRepository,EditeurRepository>();
        services.AddScoped<IVilleRepository,VilleRepository>();

        services.AddScoped<IDiplomeRepository,DiplomeRepository>();
        services.AddScoped<IDisciplineRepository,DisciplineRepository>();
        services.AddScoped<IEtablissementRepository,EtablissementRepository>();
        services.AddScoped<ILangueRepository,LangueRepository>();
        services.AddScoped<IThemeRepository,ThemeRepository>();
        

        
        services.AddScoped<INoticeService,NoticeService>();
        services.AddScoped<IDashboardService, DashboardService>();
        services.AddScoped<IPeriodiqueService, PeriodiqueService>();
        return services;
    }
}
