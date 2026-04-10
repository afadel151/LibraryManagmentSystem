using Borrowing.Worker.Repositories;
using Microsoft.Extensions.Logging;

namespace Borrowing.Worker.Services;

public interface IScopedPenaltieService
{
}

public sealed class ScopedPenaltieService(
    IPenaliteRepository penaliteRepository,
    ICategorieRepository categorieRepository,
    IPenaliteAdherentRepository penaliteAdherentRepository,
    IHistoriquePenaliteAdherentRepository historiquePenaliteAdherent,
    IAdherentRepository adherentRepository,
    ILogger<ScopedPretService> logger
    ) : IScopedPenaltieService
{
    private readonly IPenaliteRepository _penaliteRepository = penaliteRepository;
    private readonly ICategorieRepository _categorieRepository = categorieRepository;
    private readonly IPenaliteAdherentRepository _penaliteAdherentRepository = penaliteAdherentRepository;
    private readonly IHistoriquePenaliteAdherentRepository _historiquePenaliteAdherent = historiquePenaliteAdherent;
    private readonly IAdherentRepository _adherentRepository = adherentRepository;
    private readonly ILogger<ScopedPretService> _logger = logger;

}