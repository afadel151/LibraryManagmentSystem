using Borrowing.Api.Repositories;
using Shared.Models;
using Microsoft.EntityFrameworkCore;
namespace Borrowing.Api.Services;

public interface IAdherentService
{
    Task<Adherent?> GetAdherentWithDetailsAsync(string adherentId);
    Task<Categorie?> GetAdherentCategorie(string adherentId);
}

public class AdherentService(
    IAdherentRepository adherentRepository,
    IEtatAdherentRepository etatAdherentRepository,
    ICategorieRepository categorieRepository
) : IAdherentService
{
    private readonly IAdherentRepository _adherentRepository = adherentRepository;
    private readonly IEtatAdherentRepository _etatAdherentRepository = etatAdherentRepository;
    private readonly ICategorieRepository _categorieRepository = categorieRepository;

    // Sample method to demonstrate repository usage

    public async Task<Adherent?> GetAdherentWithDetailsAsync(string adherentId)
    {
        // Example: retrieve adherent by ID
        var adherent = await _adherentRepository.GetQueryable(a => a.Categorie!).FirstOrDefaultAsync(a=> a.IdAdherent == adherentId);
        
        if (adherent != null)
        {
            return adherent;
        }
        return null;
    }

    public async Task<Categorie?> GetAdherentCategorie(string adherentId)
    {
        return await _adherentRepository
            .GetQueryable()
            .Where(a => a.IdAdherent == adherentId)
            .Join(
                _categorieRepository.GetQueryable(),
                    a => a.IdCategorie,
                c => c.IdCategorie,
                (a, c) => c
            )
            .FirstOrDefaultAsync();
    }
}