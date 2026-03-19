using Borrowing.Api.Repositories;
using Shared.Models;

namespace Borrowing.Api.Services;

public interface IAdherentService
{
    Task<Adherent?> GetAdherentWithDetailsAsync(string adherentId);
}

public class AdherentService(
    IAdherentRepository adherentRepository,
    IEtatAdherentRepository etatAdherentRepository) : IAdherentService
{
    private readonly IAdherentRepository _adherentRepository = adherentRepository;
    private readonly IEtatAdherentRepository _etatAdherentRepository = etatAdherentRepository;

    // Sample method to demonstrate repository usage

    public async Task<Adherent?> GetAdherentWithDetailsAsync(string adherentId)
    {
        // Example: retrieve adherent by ID
        var adherent = await _adherentRepository.GetByIdAsync(adherentId);
        
        if (adherent != null)
        {
            // You can also use other repositories here if needed
            // var etat = await _etatAdherentRepository.GetByIdAsync(adherent.EtatId);
        }
        
        return adherent;
    }
}