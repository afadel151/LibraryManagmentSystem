namespace Borrowing.Web.Services;

using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using Borrowing.SharedClasses.Requests.Pret;
using Borrowing.SharedClasses.Common;
using Borrowing.SharedClasses.Responses.Pret;
using Borrowing.SharedClasses.Responses.Adherent;
using Borrowing.SharedClasses.Responses.Notice;
using Borrowing.SharedClasses.Requests.Reservation;
using Borrowing.SharedClasses.Responses.Reservation;

public interface IPretService
{
    Task<PagedResult<PretResponseDto>> GetPretsAsync(PaginatedQueryParameters queryParameters);
    Task<CreateReservationResponseDto> CreateReservation(CreateReservationRequestDto createReservationRequestDto);
    Task<PretStatsDto> GetStats();
    Task<CheckAdhPretResponseDto> CheckAdherent(string id);
    Task<CheckNoticeResponseDto> CheckNotice(string cote, string AdherentId);

    Task<CreatePretResponseDto> CreatePret(CreatePretRequestDto pretRequestDto);
}
public class PretService : IPretService
{
        private readonly HttpClient _httpClient;

    public PretService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<PagedResult<PretResponseDto>> GetPretsAsync(PaginatedQueryParameters queryParameters)
    {
        var orderBy = string.IsNullOrWhiteSpace(queryParameters.OrderBy)
                ? "DatePret desc"
                : queryParameters.OrderBy;
        var url = $"api/Pret?" +
                $"PageNumber={queryParameters.PageNumber}&" +
                $"PageSize={queryParameters.PageSize}&" +
                $"OrderBy={orderBy}";

        var response = await _httpClient.GetAsync(url);

        var content = await response.Content.ReadAsStringAsync();

        response.EnsureSuccessStatusCode();

        return JsonSerializer.Deserialize<PagedResult<PretResponseDto>>(content, new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        })!;
    }

    public async Task<PretStatsDto> GetStats()
    {
        var response = await _httpClient.GetAsync("api/Pret/Stats");
        var content = await response.Content.ReadAsStringAsync();

        response.EnsureSuccessStatusCode();
        return JsonSerializer.Deserialize<PretStatsDto>(content, new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        })!;
    }

    public async Task<CheckAdhPretResponseDto> CheckAdherent(string id)
    {
        var response = await _httpClient.GetAsync($"api/Adherent/Pret/Check?id={id}");
        var content = await response.Content.ReadAsStringAsync();

        response.EnsureSuccessStatusCode();
        return JsonSerializer.Deserialize<CheckAdhPretResponseDto>(content, new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        })!;
    }

    public async Task<CheckNoticeResponseDto> CheckNotice(string cote, string AdherentId)
    {
        var response = await _httpClient.GetAsync($"api/Notice/Pret/Check?cote={cote}&AdherentId={AdherentId}");
        var content = await response.Content.ReadAsStringAsync();

        response.EnsureSuccessStatusCode();
        return JsonSerializer.Deserialize<CheckNoticeResponseDto>(content, new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        })!;
    }

    public async Task<CreatePretResponseDto> CreatePret(CreatePretRequestDto createPretRequestDto)
    {
        var response = await _httpClient.PostAsJsonAsync($"api/Pret/Create", createPretRequestDto);
        var content = await response.Content.ReadAsStringAsync();

        response.EnsureSuccessStatusCode();
        return JsonSerializer.Deserialize<CreatePretResponseDto>(content, new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        })!;
    }
    public async Task<CreateReservationResponseDto> CreateReservation(CreateReservationRequestDto createReservationRequestDto)
    {
        var response = await _httpClient.PostAsJsonAsync($"api/Reservation/Create", createReservationRequestDto);
        var content = await response.Content.ReadAsStringAsync();

        response.EnsureSuccessStatusCode();
        return JsonSerializer.Deserialize<CreateReservationResponseDto>(content, new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        })!;
    }
}
