namespace Borrowing.Web.Services;

using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using Borrowing.SharedClasses.Models;
using Borrowing.SharedClasses.Responses.Adherent;
using System.Net;
using Borrowing.Web.Providers;
using Borrowing.SharedClasses.Requests.Restitution;

public interface IRestitutionService
{
    Task<CheckAdhRestitutionResponseDto?> CheckAdherent(string AdherentId);
    Task<bool> ValiderRestitution(CreateRestitutionDto dto);
    Task<bool> ValiderRenouvlement(CreateRestitutionDto dto);

}


public class RestitutionService(ApiHttpClient api) : IRestitutionService
{
    private readonly ApiHttpClient _api = api;
   public async Task<CheckAdhRestitutionResponseDto?> CheckAdherent(string AdherentId)
    => await _api.GetAsync<CheckAdhRestitutionResponseDto>($"api/Adherent/Restitution/Check?AdherentId={Uri.EscapeDataString(AdherentId)}");

    public async Task<bool> ValiderRestitution(CreateRestitutionDto dto) => 
        await _api.PostForSuccessAsync("api/Restitution/Restituer",dto);
    public async Task<bool> ValiderRenouvlement(CreateRestitutionDto dto) => 
        await _api.PostForSuccessAsync("api/Restitution/Renouvler",dto);
}