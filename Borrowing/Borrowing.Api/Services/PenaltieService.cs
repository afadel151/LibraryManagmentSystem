using Borrowing.Api.Repositories;
using Shared.Models;

namespace Borrowing.Api.Services;

public interface IPenaltieService
{
    Task<IEnumerable<PenaliteAdherent>> GetPenaltiesForAdherentAsync(string adherentId);
    Task<bool> DeletePenaliteAsync(string adherentId, DateTime datePenalite);
}

public class PenaltieService : IPenaltieService
{
    private readonly IPenaliteRepository _penaliteRepository;
    private readonly IPenaliteAdherentRepository _penaliteAdherentRepository;
    private readonly IHistoriquePenaliteAdherentRepository _historiquePenaliteAdherentRepository;
    private readonly IPenaliteAdherentTempRepository _penaliteAdherentTempRepository;

    public PenaltieService(
        IPenaliteRepository penaliteRepository,
        IPenaliteAdherentRepository penaliteAdherentRepository,
        IHistoriquePenaliteAdherentRepository historiquePenaliteAdherentRepository,
        IPenaliteAdherentTempRepository penaliteAdherentTempRepository)
    {
        _penaliteRepository = penaliteRepository;
        _penaliteAdherentRepository = penaliteAdherentRepository;
        _historiquePenaliteAdherentRepository = historiquePenaliteAdherentRepository;
        _penaliteAdherentTempRepository = penaliteAdherentTempRepository;
    }

    // Sample method to demonstrate repository usage
    public async Task<IEnumerable<PenaliteAdherent>> GetPenaltiesForAdherentAsync(string adherentId)
    {
        // Example: retrieve penalties (Needs actual predicate if FindAsync is implemented)
        var penalties = await _penaliteAdherentRepository.FindAsync(p => p.IdAdherent == adherentId);
        return penalties;
    }

    public async Task<bool> DeletePenaliteAsync(string adherentId, DateTime datePenalite)
    {
        var penalites = await _penaliteAdherentRepository.FindAsync(p => p.IdAdherent == adherentId && p.DatePenalite.Date == datePenalite.Date);
        var penalite = penalites.FirstOrDefault();
        if (penalite != null)
        {
            Console.WriteLine("#### penalite"+penalite.DatePenalite);
            
            await _penaliteAdherentRepository.DeleteAsync(penalite);
            
            var historique = new HistoriquePenaliteAdherent
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
}
