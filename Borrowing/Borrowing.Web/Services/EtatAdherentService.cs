using System.Net.Http.Json;
using Borrowing.SharedClasses.Responses.Adherent;
using Borrowing.Web.Providers;
namespace Borrowing.Web.Services;

public interface IEtatAdherentService
{
    Task<List<EtatAdherentDto>?> GetAllEtatsAsync();
}

public class EtatAdherentService(ApiHttpClient api) : IEtatAdherentService
{
    private readonly ApiHttpClient _api = api;

    public async Task<List<EtatAdherentDto>?> GetAllEtatsAsync()
    {
        return await _api.GetAsync<List<EtatAdherentDto>?>("api/EtatAdherent");
        
    }
}
