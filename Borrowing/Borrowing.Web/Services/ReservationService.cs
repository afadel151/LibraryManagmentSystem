namespace Borrowing.Web.Services;

using System.Net.Http;
using System.Net.Http.Json;
using System.Text.Json;
using System.Threading.Tasks;
using Borrowing.SharedClasses.Common;

public interface IReservationService
{
    Task<PagedResult<ReservationDto>> GetReservationsAsync(PaginatedQueryParameters queryParameters);
    Task<IEnumerable<ReservationDto>> GetAllReservationsAsync(string search = "");
}

public class ReservationService(IHttpClientFactory factory) : IReservationService
{
    private readonly HttpClient _httpClient = factory.CreateClient("BorrowingApi");

    public async Task<PagedResult<ReservationDto>> GetReservationsAsync(PaginatedQueryParameters queryParameters)
    {
        var orderBy = string.IsNullOrWhiteSpace(queryParameters.OrderBy)
                ? "HeureReservation desc"
                : queryParameters.OrderBy;
        var url = $"api/Reservation?" +
                $"PageNumber={queryParameters.PageNumber}&" +
                $"PageSize={queryParameters.PageSize}&" +
                $"OrderBy={orderBy}&" +
                $"Search={queryParameters.Search}";

        var response = await _httpClient.GetAsync(url);
        var content = await response.Content.ReadAsStringAsync();

        response.EnsureSuccessStatusCode();

        return JsonSerializer.Deserialize<PagedResult<ReservationDto>>(content, new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        })!;
    }

    public async Task<IEnumerable<ReservationDto>> GetAllReservationsAsync(string search = "")
    {
        var queryParams = new PaginatedQueryParameters
        {
            PageNumber = 1,
            PageSize = int.MaxValue,
            OrderBy = "HeureReservation desc",
            Search = search
        };

        var result = await GetReservationsAsync(queryParams);
        return result.Data;
    }
}
