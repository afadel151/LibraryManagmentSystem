using Borrowing.Api.Repositories;
using Borrowing.SharedClasses.Requests.Categorie;
using Borrowing.SharedClasses.Responses.Categorie;
using Microsoft.EntityFrameworkCore;
using Common.Models;

namespace Borrowing.Api.Services;

public interface ICategorieService
{
    Task<List<CategorieDto>> GetAllCategoriesAsync();
    Task<bool> UpdateCategorieAsync(UpdateCategorieDto dto);
    Task<bool> CreateCategorieAsync(CreateCategorieDto dto);
    Task<bool> DeleteCategorieAsync(string idCategorie);
}

public class CategorieService(ICategorieRepository categorieRepository, IAdherentRepository adherentRepository) : ICategorieService
{
    private readonly ICategorieRepository _categorieRepository = categorieRepository;
    private readonly IAdherentRepository _adherentRepository = adherentRepository;

    public async Task<List<CategorieDto>> GetAllCategoriesAsync()
    {
        var categories = await _categorieRepository.GetQueryable()
            .Select(c => new CategorieDto
            {
                IdCategorie = c.IdCategorie,
                LibelleCategorie = c.LibelleCategorie ?? string.Empty,
                NombreDocument = c.NombreDocument,
                DureePret = c.DureePret
            })
            .ToListAsync();

        // Get adherent counts per category
        var adherentCounts = await _adherentRepository.GetQueryable()
                                .GroupBy(a => a.IdCategorie)
                                .Select(g => new { IdCategorie = g.Key, Count = g.Count() })
                                .ToDictionaryAsync(x => x.IdCategorie, x => x.Count);

        foreach (var categorie in categories)
        {
            categorie.AdherentCount = adherentCounts.TryGetValue(categorie.IdCategorie, out var count) ? count : 0;
        }

        return categories;
    }

    public async Task<bool> UpdateCategorieAsync(UpdateCategorieDto dto)
    {
        ArgumentNullException.ThrowIfNull(dto);
        var categorie = await _categorieRepository.GetQueryable()
            .FirstOrDefaultAsync(c => c.IdCategorie == dto.IdCategorie);

        if (categorie == null) return false;

        categorie.NombreDocument = dto.NombreDocument;
        categorie.DureePret = dto.DureePret;

        try
        {
            await _categorieRepository.UpdateAsync(categorie);
            return true;
        }
        catch (Exception)
        {
            return false;
        }
    }

    public async Task<bool> CreateCategorieAsync(CreateCategorieDto dto)
    {
        ArgumentNullException.ThrowIfNull(dto);
        var categorie = new Categorie
        {
            IdCategorie = dto.IdCategorie,
            LibelleCategorie = dto.LibelleCategorie,
            NombreDocument = dto.NombreDocument,
            DureePret = dto.DureePret
        };

        try
        {
            await _categorieRepository.AddAsync(categorie);
            return true;
        }
        catch (Exception)
        {
            return false;
        }
    }

    public async Task<bool> DeleteCategorieAsync(string idCategorie)
    {
        ArgumentNullException.ThrowIfNull(idCategorie);
        var categorie = await _categorieRepository.GetQueryable()
            .FirstOrDefaultAsync(c => c.IdCategorie == idCategorie);

        if (categorie == null) return false;

        try
        {
            await _categorieRepository.DeleteAsync(categorie);
            return true;
        }
        catch (Exception)
        {
            return false;
        }
    }
}