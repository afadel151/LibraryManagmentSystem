using Borrowing.Api.Repositories;
using Borrowing.SharedClasses.Responses.Categorie;
using Microsoft.EntityFrameworkCore;

namespace Borrowing.Api.Services;

public interface ICategorieService
{
    Task<IEnumerable<CategorieDto>> GetAllCategoriesAsync();
}

public class CategorieService(ICategorieRepository categorieRepository) : ICategorieService
{
    private readonly ICategorieRepository _categorieRepository = categorieRepository;

    public async Task<IEnumerable<CategorieDto>> GetAllCategoriesAsync()
    {
        return await _categorieRepository.GetQueryable()
            .Select(c => new CategorieDto
            {
                IdCategorie = c.IdCategorie,
                LibelleCategorie = c.LibelleCategorie ?? string.Empty
            })
            .ToListAsync();
    }
}