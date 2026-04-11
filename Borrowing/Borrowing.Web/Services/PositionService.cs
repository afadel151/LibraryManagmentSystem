using System.Net.Http.Json;
using Borrowing.SharedClasses.Responses.Position;

namespace Borrowing.Web.Services;
using Borrowing.Web.Providers;
public interface IPositionService
{
    Task<List<PositionDto>?> GetAllPositionsAsync();
}

public class PositionService(ApiHttpClient api) : IPositionService
{
    private readonly ApiHttpClient _api = api;

    public async Task<List<PositionDto>?> GetAllPositionsAsync()
    {
        return await _api.GetAsync<List<PositionDto>?>("api/Position");
    }
}
