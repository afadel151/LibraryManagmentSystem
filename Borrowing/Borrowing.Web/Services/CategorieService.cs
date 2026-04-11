using System.Net.Http.Json;
using Borrowing.SharedClasses.Requests.Categorie;
using Borrowing.SharedClasses.Responses.Categorie;
using Borrowing.Web.Providers;

namespace Borrowing.Web.Services;

public interface ICategorieService
{
    Task<List<CategorieDto>?> GetAllCategoriesAsync();
    Task<bool> UpdateCategorieAsync(UpdateCategorieDto dto);
    Task<bool> CreateCategorieAsync(CreateCategorieDto dto);
    Task<bool> DeleteCategorieAsync(string idCategorie);
}

public class CategorieService(ApiHttpClient api) : ICategorieService
{
    private readonly ApiHttpClient _api = api;

    public async Task<List<CategorieDto>?> GetAllCategoriesAsync()
    {
        return await _api.GetAsync<List<CategorieDto>?>("api/Categorie");
    }

    public async Task<bool> UpdateCategorieAsync(UpdateCategorieDto dto) =>
        await _api.PutForSuccessAsync("api/Categorie", dto);

    public async Task<bool> CreateCategorieAsync(CreateCategorieDto dto) =>
        await _api.PostForSuccessAsync("api/Categorie", dto);

    public async Task<bool> DeleteCategorieAsync(string idCategorie) =>
        await _api.DeleteForSuccessAsync($"api/Categorie/{idCategorie}");
}
