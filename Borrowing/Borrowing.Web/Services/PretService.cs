namespace Borrowing.Web.Services;
using Borrowing.Web.Providers;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using Borrowing.SharedClasses.Requests.Pret;
using Borrowing.SharedClasses.Models;
using Borrowing.SharedClasses.Responses.Pret;
using Borrowing.SharedClasses.Responses.Adherent;
using Borrowing.SharedClasses.Responses.Notice;
using Borrowing.SharedClasses.Requests.Reservation;
using Borrowing.SharedClasses.Responses.Reservation;

public interface IPretService
{
    Task<PagedResult<PretResponseDto>?> GetPretsAsync(PaginatedQueryParameters queryParameters);
    Task<IEnumerable<PretResponseDto>> GetAllPretsAsync(string search = "");
    Task<CreateReservationResponseDto?> CreateReservation(CreateReservationRequestDto createReservationRequestDto);
    Task<PretStatsDto?> GetStats();
    Task<CheckAdhPretResponseDto?> CheckAdherent(string id);
    Task<CheckNoticeResponseDto?> CheckNotice(string cote, string AdherentId);

    Task<CreatePretResponseDto?> CreatePret(CreatePretRequestDto pretRequestDto);
}
public class PretService(ApiHttpClient api) : IPretService
{
    private readonly ApiHttpClient _api = api;

    public async Task<PagedResult<PretResponseDto>?> GetPretsAsync(PaginatedQueryParameters queryParameters)
    {
        var orderBy = string.IsNullOrWhiteSpace(queryParameters.OrderBy)
                ? "datepret desc"
                : queryParameters.OrderBy;
        var url = $"api/Pret?" +
                $"PageNumber={queryParameters.PageNumber}&" +
                $"PageSize={queryParameters.PageSize}&" +
                $"OrderBy={orderBy}&" +
                $"Search={queryParameters.Search}";

        return await _api.GetAsync<PagedResult<PretResponseDto>?>(url);

    }
    // In IPretService / PretService
    public async Task<IEnumerable<PretResponseDto>> GetAllPretsAsync(string search = "")
    {
        var queryParams = new PaginatedQueryParameters
        {
            PageNumber = 1,
            PageSize = int.MaxValue,
            OrderBy = "datepret desc",
            Search = search
        };

        var result = await GetPretsAsync(queryParams);
        return result!.Data;
    }
    public async Task<PretStatsDto?> GetStats()
    {
        return await _api.GetAsync<PretStatsDto?>("api/Pret/Stats"); 
    }

    public async Task<CheckAdhPretResponseDto?> CheckAdherent(string id)
    {
        return await _api.GetAsync<CheckAdhPretResponseDto?>($"api/Adherent/Pret/Check?id={id}");
    }

    public async Task<CheckNoticeResponseDto?> CheckNotice(string cote, string AdherentId)
    {
        return await _api.GetAsync<CheckNoticeResponseDto?>($"api/Notice/Pret/Check?cote={cote}&AdherentId={AdherentId}");
    }

    public async Task<CreatePretResponseDto?> CreatePret(CreatePretRequestDto createPretRequestDto)
    {
        return await _api.PostAsync<CreatePretResponseDto>($"api/Pret/Create", createPretRequestDto);
        
    }
    public async Task<CreateReservationResponseDto?> CreateReservation(CreateReservationRequestDto createReservationRequestDto)
    {
        return await _api.PostAsync<CreateReservationResponseDto?>($"api/Reservation/Create", createReservationRequestDto);

    }
}
