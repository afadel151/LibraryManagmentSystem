using Borrowing.Api.Repositories;
using Shared.Models;

namespace Borrowing.Api.Services;

public interface IRelanceService
{
    Task ProcessRelancesAsync();
}

public class RelanceService : IRelanceService
{
    private readonly IPretRepository _pretRepository;
    private readonly IAdherentRepository _adherentRepository;

    public RelanceService(
        IPretRepository pretRepository,
        IAdherentRepository adherentRepository)
    {
        _pretRepository = pretRepository;
        _adherentRepository = adherentRepository;
    }

    // Sample method to demonstrate repository usage
    public async Task ProcessRelancesAsync()
    {
        // Example: process overdue borrowings (relances)
        // var overduePrets = await _pretRepository.FindAsync(p => p.DateRetourPrevu < DateTime.Now && p.DateRetourReel == null);
        await Task.CompletedTask;
    }
}