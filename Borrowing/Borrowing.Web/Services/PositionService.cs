using System.Net.Http.Json;
using Borrowing.SharedClasses.Responses.Position;

namespace Borrowing.Web.Services;

public interface IPositionService
{
    Task<IEnumerable<PositionDto>> GetAllPositionsAsync();
}

public class PositionService(IHttpClientFactory factory) : IPositionService
{
    private readonly HttpClient _httpClient = factory.CreateClient("BorrowingApi");

    public async Task<IEnumerable<PositionDto>> GetAllPositionsAsync()
    {
        var response = await _httpClient.GetAsync("api/Position");
        response.EnsureSuccessStatusCode();

        return await response.Content.ReadFromJsonAsync<IEnumerable<PositionDto>>() ?? Array.Empty<PositionDto>();
    }
}
