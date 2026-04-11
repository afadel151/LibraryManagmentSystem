namespace Borrowing.Web.Services;

using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using Borrowing.SharedClasses.Models;
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

public class AdherentService(ApiHttpClient api) : IAdherentService
{
    private readonly ApiHttpClient _api = api;

    public async Task<AdherentsStatsDto?> GetStats() =>
        await _api.GetAsync<AdherentsStatsDto>("api/Adherent/Stats");

    public async Task<AdherentProfileDto?> GetAdherent(string id) =>
        await _api.GetAsync<AdherentProfileDto>($"api/Adherent/Profile?Id={Uri.EscapeDataString(id)}");

    public async Task<PagedResult<AdherentDto>?> GetAdherentsAsync(PaginatedQueryParameters queryParameters)
    {
        var orderBy = string.IsNullOrWhiteSpace(queryParameters.OrderBy)
                   ? "datepret desc"
                   : queryParameters.OrderBy;

        var url = $"api/Adherent?" +
                  $"PageNumber={queryParameters.PageNumber}&" +
                  $"PageSize={queryParameters.PageSize}&" +
                  $"Search={Uri.EscapeDataString(queryParameters.Search ?? "")}&" +
                  $"OrderBy={Uri.EscapeDataString(orderBy)}";

        return await _api.GetAsync<PagedResult<AdherentDto>>(url);
    }

    public async Task<IEnumerable<AdherentDto>> GetAllAdherentsAsync(string search = "")
    {
        var result = await GetAdherentsAsync(new PaginatedQueryParameters
        {
            PageNumber = 1,
            PageSize = int.MaxValue,
            OrderBy = "datepret desc",
            Search = search
        });
        return result?.Data ?? Enumerable.Empty<AdherentDto>();
    }

    public async Task<bool> CreateAdherentAsync(CreateAdherentDto dto) =>
        await _api.PostForSuccessAsync("api/Adherent", dto);

    public async Task<bool> UpdateAdherentAsync(UpdateAdherentDto dto) =>
        await _api.PutForSuccessAsync("api/Adherent", dto);

    public async Task<bool> DeletePenaliteAsync(string adherentId, DateTime datePenalite) =>
        await _api.DeleteForSuccessAsync(
            $"api/PenaliteAdherent/{Uri.EscapeDataString(adherentId)}/{datePenalite:yyyy-MM-ddTHH:mm:ss}");
}