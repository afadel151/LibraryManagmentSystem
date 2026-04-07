using Borrowing.Worker.Repositories;
using Microsoft.EntityFrameworkCore;
using Shared.Models;

namespace Borrowing.Worker.Services;



public class PenaltieService(
    PenaliteRepository penaliteRepository,
    CategorieRepository categorieRepository,
    PenaliteAdherentRepository penaliteAdherentRepository,
    HistoriquePenaliteAdherent historiquePenaliteAdherent,
    AdherentRepository adherentRepository
    ) 
{
    private readonly PenaliteRepository _penaliteRepository = penaliteRepository;
    private readonly CategorieRepository _categorieRepository = categorieRepository;
    private readonly PenaliteAdherentRepository _penaliteAdherentRepository = penaliteAdherentRepository;
    private readonly HistoriquePenaliteAdherent _historiquePenaliteAdherent = historiquePenaliteAdherent;
    private readonly  AdherentRepository _adherentRepository = adherentRepository;

}