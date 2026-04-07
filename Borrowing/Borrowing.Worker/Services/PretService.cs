
using Borrowing.Worker.Repositories;
using Shared.Models;
using Microsoft.EntityFrameworkCore;
using Borrowing.Worker.Extensions;

namespace Borrowing.Worker.Services;

public class PretService(
    PretRepository pretRepository,
    HistoriquePenaliteAdherentRepository historiquePretRepository,
    ExemplairesRepository exemplairesRepository,
    AdherentRepository adherentRepository,
    CategorieRepository categorieRepository,
    PenaliteAdherentRepository penaliteAdherentRepository,
    PenaliteRepository penaliteRepository,
    JoursFeriesRepository joursFeriesRepository,
    ReservationRepository reservationRepository
    ) 
{
    private readonly PretRepository _pretRepository = pretRepository;
    private readonly JoursFeriesRepository _joursFeriesRepository = joursFeriesRepository;
    private readonly PenaliteAdherentRepository _penaliteAdherentRepository = penaliteAdherentRepository;
    private readonly PenaliteRepository _penaliteRepository = penaliteRepository;
    private readonly HistoriquePenaliteAdherentRepository _historiquePretRepository = historiquePretRepository;
    private readonly ExemplairesRepository _exemplairesRepository = exemplairesRepository;
    private readonly AdherentRepository _adherentRepository = adherentRepository;
    private readonly ReservationRepository _reservationRepository = reservationRepository;
    private readonly CategorieRepository _categorieRepository = categorieRepository;

   

    
}