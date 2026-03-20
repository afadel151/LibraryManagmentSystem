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
            return adherent;
        }
        return null;
    }

    public async Task<Categorie?> GetAdherentCategorie(string adherentId)
    {
        var adherents = _adherentRepository.GetQueryable();
        var categories = _categorieRepository.GetQueryable();
        var query = from adherent in adherents
                    join categorie in categories on adherent.IdCategorie equals categorie.IdCategorie
                    where adherent.IdAdherent == adherentId
                    select categorie;
            return await query.FirstOrDefaultAsync();
    }
}