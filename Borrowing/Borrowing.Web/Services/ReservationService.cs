namespace Borrowing.Web.Services;

using System.Net.Http;
using System.Net.Http.Json;
using System.Text.Json;
using System.Threading.Tasks;
using Borrowing.SharedClasses.Common;
using Borrowing.Web.Providers;

public interface IReservationService
{
    Task<PagedResult<ReservationDto>?> GetReservationsAsync(PaginatedQueryParameters queryParameters);
    Task<IEnumerable<ReservationDto>?> GetAllReservationsAsync(string search = "");
    Task<List<RelanceDto>?> GetRelancesAsync();
}

public class ReservationService(ApiHttpClient api) : IReservationService
{
    private readonly ApiHttpClient _api = api;
    public async Task<PagedResult<ReservationDto>?> GetReservationsAsync(PaginatedQueryParameters queryParameters)
    {
        var orderBy = string.IsNullOrWhiteSpace(queryParameters.OrderBy)
                ? "HeureReservation desc"
                : queryParameters.OrderBy;

        var url = $"api/Reservation?" +
                $"PageNumber={queryParameters.PageNumber}&" +
                $"PageSize={queryParameters.PageSize}&" +
                $"OrderBy={orderBy}&" +
                $"Search={queryParameters.Search}";

        return await _api.GetAsync<PagedResult<ReservationDto>>(url);
    }

    public async Task<IEnumerable<ReservationDto>?> GetAllReservationsAsync(string search = "")
    {
        var queryParams = new PaginatedQueryParameters
        {
            PageNumber = 1,
            PageSize = int.MaxValue,
            OrderBy = "HeureReservation desc",
            Search = search
        };
        var result = await GetReservationsAsync(queryParams);
        if(result == null) return null;
        return result.Data;
    }

    public async Task<List<RelanceDto>?> GetRelancesAsync()
    {
        return await _api.GetAsync<List<RelanceDto>>("api/Reservation/Relances");
    }
}
