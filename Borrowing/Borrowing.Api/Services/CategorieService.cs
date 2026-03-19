using Borrowing.Api.Repositories;
using Shared.Models;

namespace Borrowing.Api.Services;

public interface ICategorieService
{
    Task<IEnumerable<Categorie>> GetAllCategoriesAsync();
}

public class CategorieService : ICategorieService
{
    private readonly ICategorieRepository _categorieRepository;

    public CategorieService(ICategorieRepository categorieRepository)
    {
        _categorieRepository = categorieRepository;
    }

    // Sample method to demonstrate repository usage
    public async Task<IEnumerable<Categorie>> GetAllCategoriesAsync()
    {
        // Example: retrieve all categories
        return await _categorieRepository.GetAllAsync();
    }
}