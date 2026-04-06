namespace Borrowing.Web.Services;

using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using Borrowing.SharedClasses.Common;
using Borrowing.SharedClasses.Requests.JoursFery;
using Borrowing.Web.Providers;

public interface IJoursFeriesService
{
    Task<PagedResult<JoursFeryDto>?> GetJoursFeriesAsync(PaginatedQueryParameters queryParameters);
    Task<IEnumerable<JoursFeryDto>> GetAllJoursFeriesAsync();
    Task<bool> CreateJoursFeryAsync(CreateJoursFeryDto dto);
    Task<bool> UpdateJoursFeryAsync(UpdateJoursFeryDto dto);
    Task<bool> DeleteJoursFeryAsync(DateTime dateJourFerie);
}

public class JoursFeriesService(ApiHttpClient api) : IJoursFeriesService
{
    private readonly ApiHttpClient _api = api;

    public async Task<PagedResult<JoursFeryDto>?> GetJoursFeriesAsync(PaginatedQueryParameters queryParameters)
    {
        var orderBy = string.IsNullOrWhiteSpace(queryParameters.OrderBy)
                   ? "datejourferie desc"
                   : queryParameters.OrderBy;

        var url = $"api/JoursFeries?" +
                  $"PageNumber={queryParameters.PageNumber}&" +
                  $"PageSize={queryParameters.PageSize}&" +
                  $"Search={Uri.EscapeDataString(queryParameters.Search ?? "")}&" +
                  $"OrderBy={Uri.EscapeDataString(orderBy)}";

        return await _api.GetAsync<PagedResult<JoursFeryDto>>(url);
    }

    public async Task<IEnumerable<JoursFeryDto>> GetAllJoursFeriesAsync()
    {
        var result = await _api.GetAsync<IEnumerable<JoursFeryDto>>("api/JoursFeries/All");
        return result ?? Enumerable.Empty<JoursFeryDto>();
    }

    public async Task<bool> CreateJoursFeryAsync(CreateJoursFeryDto dto) =>
        await _api.PostForSuccessAsync("api/JoursFeries", dto);

    public async Task<bool> UpdateJoursFeryAsync(UpdateJoursFeryDto dto) =>
        await _api.PutForSuccessAsync("api/JoursFeries", dto);

    public async Task<bool> DeleteJoursFeryAsync(DateTime dateJourFerie) =>
        await _api.DeleteForSuccessAsync($"api/JoursFeries/{dateJourFerie:yyyy-MM-ddTHH:mm:ss}");
}