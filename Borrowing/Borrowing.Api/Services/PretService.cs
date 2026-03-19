using Borrowing.Api.Repositories;
using Shared.Models;

namespace Borrowing.Api.Services;

public interface IPretService
{
    Task<Pret?> CreatePretAsync(Pret pret);
}

public class PretService : IPretService
{
    private readonly IPretRepository _pretRepository;
    private readonly IHistoriquePretRepository _historiquePretRepository;
    private readonly IExemplairesRepository _exemplairesRepository;
    private readonly IAdherentRepository _adherentRepository;

    public PretService(
        IPretRepository pretRepository,
        IHistoriquePretRepository historiquePretRepository,
        IExemplairesRepository exemplairesRepository,
        IAdherentRepository adherentRepository)
    {
        _pretRepository = pretRepository;
        _historiquePretRepository = historiquePretRepository;
        _exemplairesRepository = exemplairesRepository;
        _adherentRepository = adherentRepository;
    }

    // Sample method to demonstrate repository usage
    public async Task<Pret?> CreatePretAsync(Pret pret)
    {
        // Example: create a new borrowing record
        await _pretRepository.AddAsync(pret);
        return pret;
    }
}