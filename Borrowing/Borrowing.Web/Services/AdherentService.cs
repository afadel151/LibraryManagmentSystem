namespace Borrowing.Web.Services;

using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using Borrowing.SharedClasses.Common;
using Borrowing.SharedClasses.Responses.Adherent;
using System.Net;
using Borrowing.Web.Providers;
using Borrowing.SharedClasses.Requests.Adherent;

public interface IAdherentService
{

    Task<AdherentsStatsDto?> GetStats();
    Task<AdherentProfileDto?> GetAdherent(string id);
    Task<PagedResult<AdherentDto>?> GetAdherentsAsync(PaginatedQueryParameters queryParameters);
    Task<IEnumerable<AdherentDto>> GetAllAdherentsAsync(string search = "");
    Task<bool> CreateAdherentAsync(CreateAdherentDto dto);
    Task<bool> DeletePenaliteAsync(string adherentId, DateTime datePenalite);
    Task<bool> UpdateAdherentAsync(UpdateAdherentDto dto);
}

public class AdherentService : IAdherentService
{
    private readonly ApiHttpClient _api;

    public AdherentService(ApiHttpClient api)
    {
        _api = api;
    }

    public Task<AdherentsStatsDto?> GetStats() =>
        _api.GetAsync<AdherentsStatsDto>("api/Adherent/Stats");

    public Task<AdherentProfileDto?> GetAdherent(string id) =>
        _api.GetAsync<AdherentProfileDto>($"api/Adherent/Profile?Id={Uri.EscapeDataString(id)}");

    public Task<PagedResult<AdherentDto>?> GetAdherentsAsync(PaginatedQueryParameters queryParameters)
    {
        var orderBy = string.IsNullOrWhiteSpace(queryParameters.OrderBy)
                   ? "datepret desc"
                   : queryParameters.OrderBy;

        var url = $"api/Adherent?" +
                  $"PageNumber={queryParameters.PageNumber}&" +
                  $"PageSize={queryParameters.PageSize}&" +
                  $"Search={Uri.EscapeDataString(queryParameters.Search ?? "")}&" +
                  $"OrderBy={Uri.EscapeDataString(orderBy)}";

        return _api.GetAsync<PagedResult<AdherentDto>>(url);
    }

    public async Task<IEnumerable<AdherentDto>> GetAllAdherentsAsync(string search = "")
    {
        var result = await GetAdherentsAsync(new PaginatedQueryParameters
        {
            PageNumber = 1,
            PageSize   = int.MaxValue,
            OrderBy    = "datepret desc",
            Search     = search
        });
        return result?.Data ?? Enumerable.Empty<AdherentDto>();
    }

    public Task<bool> CreateAdherentAsync(CreateAdherentDto dto) =>
        _api.PostForSuccessAsync("api/Adherent", dto);

    public Task<bool> UpdateAdherentAsync(UpdateAdherentDto dto) =>
        _api.PutForSuccessAsync("api/Adherent", dto);

    public Task<bool> DeletePenaliteAsync(string adherentId, DateTime datePenalite) =>
        _api.DeleteForSuccessAsync(
            $"api/Penalite/{Uri.EscapeDataString(adherentId)}/{datePenalite:yyyy-MM-ddTHH:mm:ss}");
}