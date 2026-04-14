using Borrowing.Api.Repositories;
using Borrowing.SharedClasses.Models;
using Microsoft.EntityFrameworkCore;
using Common.Models;
using System.Data.Common;

namespace Borrowing.Api.Services;

public interface IPenaliteAdherentService
{
    Task<IEnumerable<PenaliteAdherent>> GetPenaltiesForAdherentAsync(string adherentId);
    Task<bool> DeletePenaliteAsync(string adherentId, DateTime datePenalite);
    Task<int> CountNegativePenalties();
    Task<List<RelanceRetardDto>> GetRelancesRetard();
}

public class PenaltieAdherentService(
    IPenaliteAdherentRepository penaliteAdherentRepository,
    IHistoriquePenaliteAdherentRepository historiquePenaliteAdherentRepository,
    ILogger<PenaltieAdherentService> logger
    ) : IPenaliteAdherentService
{
    private readonly IPenaliteAdherentRepository _penaliteAdherentRepository = penaliteAdherentRepository;
    private readonly IHistoriquePenaliteAdherentRepository _historiquePenaliteAdherentRepository = historiquePenaliteAdherentRepository;
    private readonly ILogger<PenaltieAdherentService> _logger = logger;


    // Sample method to demonstrate repository usage
    public async Task<IEnumerable<PenaliteAdherent>> GetPenaltiesForAdherentAsync(string adherentId)
    {
        ArgumentNullException.ThrowIfNull(adherentId);
        // Example: retrieve penalties (Needs actual predicate if FindAsync is implemented)
        var penalties = await _penaliteAdherentRepository.FindAsync(p => p.IdAdherent == adherentId);
        return penalties;
    }

    public async Task<bool> DeletePenaliteAsync(string adherentId, DateTime datePenalite)
    {
        ArgumentNullException.ThrowIfNull(adherentId);
        var penalite = await _penaliteAdherentRepository.GetQueryable()
                        .Where(p => p.IdAdherent == adherentId && p.DatePenalite.Date == datePenalite.Date)
                        .FirstOrDefaultAsync();
        if (penalite != null)
        {
            Console.WriteLine("#### penalite" + penalite.DatePenalite);

            await _penaliteAdherentRepository.DeleteAsync(penalite);

            HistoriquePenaliteAdherent historique = new()
            {
                IdAdherent = penalite.IdAdherent,
                DatePenalite = penalite.DatePenalite,
                NombreJoursPenalite = penalite.NombreJoursPenalite
            };
            await _historiquePenaliteAdherentRepository.AddAsync(historique);

            return true;
        }

        return false;
    }

    public async Task<int> CountNegativePenalties()
    {
        int penalties = await _penaliteAdherentRepository.GetQueryable().CountAsync(p => p.NombreJoursPenalite < 0);
        return penalties;
    }


    public async Task<List<RelanceRetardDto>> GetRelancesRetard()
    {
        try
        {
            var adherentsPenalises = await _penaliteAdherentRepository.GetQueryable()
                                            .Include(p => p.Adherent)
                                                .ThenInclude(a => a.Categorie)
                                            .Include(p => p.Adherent)
                                                .ThenInclude(a => a.Position)
                                            .Include(p => p.Adherent)
                                                .ThenInclude(a => a.Prets)
                                            .Where(p => p.NombreJoursPenalite < 0)
                                            .ToListAsync();
            var result = from p in adherentsPenalises
                         select new RelanceRetardDto
                         {
                             IdAdherent = p.IdAdherent,
                             Nom = p.Adherent.Nom ?? "",
                             Prenom = p.Adherent.Prenom ?? "",
                             Position = p.Adherent.Position?.LibellePosition ?? "",
                             Categorie = p.Adherent.Categorie?.LibelleCategorie ?? "",
                             PretsEncours = p.Adherent.Prets.Count,
                             PenaliteEnCours = (int)p.NombreJoursPenalite!
                         };

            return [.. result];

        }
        catch (DbException ex)
        {
            _logger.LogError(ex.Message);
            return [];
        }
    }
}
