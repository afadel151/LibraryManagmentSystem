namespace Borrowing.Web.Services;

using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using Borrowing.SharedClasses.Common;
using Borrowing.SharedClasses.Responses.Adherent;
using System.Net;

public interface IRestitutionService
{
    Task<CheckAdhRestitutionResponseDto> CheckAdherent(string AdherentId);
}


public class RestitutionService(HttpClient httpClient) : IRestitutionService
{
    private readonly HttpClient _httpClient = httpClient;
   public async Task<CheckAdhRestitutionResponseDto> CheckAdherent(string AdherentId)
    {
        var response = await _httpClient.GetAsync($"api/Adherent/Restitution/Check?AdherentId={AdherentId}");
        var content = await response.Content.ReadAsStringAsync();

        response.EnsureSuccessStatusCode();
        return JsonSerializer.Deserialize<CheckAdhRestitutionResponseDto>(content, new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        })!;
    }
}