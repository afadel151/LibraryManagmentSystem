using System.Net.Http.Json;
using Borrowing.SharedClasses.Responses.Adherent;

namespace Borrowing.Web.Services;

public interface IEtatAdherentService
{
    Task<IEnumerable<EtatAdherentDto>> GetAllEtatsAsync();
}

public class EtatAdherentService(IHttpClientFactory factory) : IEtatAdherentService
{
    private readonly HttpClient _httpClient = factory.CreateClient("BorrowingApi");

    public async Task<IEnumerable<EtatAdherentDto>> GetAllEtatsAsync()
    {
        var response = await _httpClient.GetAsync("api/EtatAdherent");
        response.EnsureSuccessStatusCode();

        return await response.Content.ReadFromJsonAsync<IEnumerable<EtatAdherentDto>>() ?? Array.Empty<EtatAdherentDto>();
    }
}
