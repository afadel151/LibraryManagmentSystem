namespace Borrowing.Web.Services;

using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using Borrowing.SharedClasses.Common;
using Borrowing.SharedClasses.Requests.Penalite;
using Borrowing.Web.Providers;

public interface IPenaliteService
{
    Task<PagedResult<PenaliteDto>?> GetPenalitesAsync(PaginatedQueryParameters queryParameters);
    Task<IEnumerable<PenaliteDto>> GetAllPenalitesAsync();
    Task<bool> CreatePenaliteAsync(CreatePenaliteDto dto);
    Task<bool> UpdatePenaliteAsync(UpdatePenaliteDto dto);
    Task<bool> DeletePenaliteAsync(string idCategorie);
}

public class PenaliteService(ApiHttpClient api) : IPenaliteService
{
    private readonly ApiHttpClient _api = api;

    public async Task<PagedResult<PenaliteDto>?> GetPenalitesAsync(PaginatedQueryParameters queryParameters)
    {
        var orderBy = string.IsNullOrWhiteSpace(queryParameters.OrderBy)
                   ? "idcategorie asc"
                   : queryParameters.OrderBy;

        var url = $"api/Penalite?" +
                  $"PageNumber={queryParameters.PageNumber}&" +
                  $"PageSize={queryParameters.PageSize}&" +
                  $"Search={Uri.EscapeDataString(queryParameters.Search ?? "")}&" +
                  $"OrderBy={Uri.EscapeDataString(orderBy)}";

        return await _api.GetAsync<PagedResult<PenaliteDto>>(url);
    }

    public async Task<IEnumerable<PenaliteDto>> GetAllPenalitesAsync()
    {
        var result = await _api.GetAsync<IEnumerable<PenaliteDto>>("api/Penalite/All");
        return result ?? Enumerable.Empty<PenaliteDto>();
    }

    public async Task<bool> CreatePenaliteAsync(CreatePenaliteDto dto) =>
        await _api.PostForSuccessAsync("api/Penalite", dto);

    public async Task<bool> UpdatePenaliteAsync(UpdatePenaliteDto dto) =>
        await _api.PutForSuccessAsync("api/Penalite", dto);

    public async Task<bool> DeletePenaliteAsync(string idCategorie) =>
        await _api.DeleteForSuccessAsync($"api/Penalite/{Uri.EscapeDataString(idCategorie)}");
}