
using Borrowing.Worker.Repositories;
using Borrowing.Worker.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Borrowing.Worker.Services;

public sealed class ScopedPretService(
    IPretRepository pretRepository,
    IHistoriquePenaliteAdherentRepository historiquePretRepository,
    IExemplairesRepository exemplairesRepository,
    IAdherentRepository adherentRepository,
    ICategorieRepository categorieRepository,
    IPenaliteAdherentRepository penaliteAdherentRepository,
    IPenaliteRepository penaliteRepository,
    IJoursFeriesRepository joursFeriesRepository,
    IReservationRepository reservationRepository,
    ILogger<ScopedPretService> logger
    ) : IScopedPretService
{
    private readonly IPretRepository _pretRepository = pretRepository;
    private readonly IJoursFeriesRepository _joursFeriesRepository = joursFeriesRepository;
    private readonly IPenaliteAdherentRepository _penaliteAdherentRepository = penaliteAdherentRepository;
    private readonly IPenaliteRepository _penaliteRepository = penaliteRepository;
    private readonly IHistoriquePenaliteAdherentRepository _historiquePretRepository = historiquePretRepository;
    private readonly IExemplairesRepository _exemplairesRepository = exemplairesRepository;
    private readonly IAdherentRepository _adherentRepository = adherentRepository;
    private readonly IReservationRepository _reservationRepository = reservationRepository;
    private readonly ICategorieRepository _categorieRepository = categorieRepository;
    private readonly ILogger<ScopedPretService> _logger = logger;



    public async Task Run()
    {
        var result = await _pretRepository.GetQueryable()
                        .ToListAsync();
        Console.WriteLine("##############"+result.Count);
    } 

    
}