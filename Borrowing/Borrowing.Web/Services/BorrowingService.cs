namespace Borrowing.Web.Services;

using System.Net.Http;
using System.Net.Http.Json;
using System.Text.Json;
using System.Threading.Tasks;
using Borrowing.Shared.Requests.Pret;
using Borrowing.Shared.Responses.Pret;

public class BorrowingService : IBorrowingService
{
    private readonly HttpClient _httpClient;

    public BorrowingService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<PagedResult<PretResponseDto>> GetPretsAsync(PretQueryParameters query)
    {
        var orderBy = string.IsNullOrWhiteSpace(query.OrderBy)
                ? "DatePret desc"
                : query.OrderBy;
        var url = $"api/Borrowing?" +
                $"PageNumber={query.PageNumber}&" +
                $"PageSize={query.PageSize}&" +
                $"OrderBy={orderBy}";

        var response = await _httpClient.GetAsync(url);

        var content = await response.Content.ReadAsStringAsync();
        // Console.WriteLine(content);

        response.EnsureSuccessStatusCode();

        return JsonSerializer.Deserialize<PagedResult<PretResponseDto>>(content, new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        })!;
    }
}
