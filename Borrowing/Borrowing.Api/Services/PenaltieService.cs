using Borrowing.Api.Repositories;
using Shared.Models;

namespace Borrowing.Api.Services;

public interface IPenaltieService
{
    Task<IEnumerable<PenaliteAdherent>> GetPenaltiesForAdherentAsync(string adherentId);
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
}
