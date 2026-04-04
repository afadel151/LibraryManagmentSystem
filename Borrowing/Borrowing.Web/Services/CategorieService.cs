using System.Net.Http.Json;
using Borrowing.SharedClasses.Responses.Categorie;

namespace Borrowing.Web.Services;

public interface ICategorieService
{
    Task<IEnumerable<CategorieDto>> GetAllCategoriesAsync();
}

public class CategorieService(IHttpClientFactory factory) : ICategorieService
{
    private readonly HttpClient _httpClient = factory.CreateClient("BorrowingApi");

    public async Task<IEnumerable<CategorieDto>> GetAllCategoriesAsync()
    {
        var response = await _httpClient.GetAsync("api/Categorie");
        response.EnsureSuccessStatusCode();

        return await response.Content.ReadFromJsonAsync<IEnumerable<CategorieDto>>() ?? Array.Empty<CategorieDto>();
    }
}
