using Borrowing.Api.Repositories;
using Microsoft.EntityFrameworkCore;
using Shared.Models;

namespace Borrowing.Api.Services;

public interface INoticeService
{
    Task<Notice?> GetNoticeAsync(string cote);
}

public class NoticeService : INoticeService
{
    private readonly INoticesRepository _noticesRepository;
    private readonly IExemplairesRepository _exemplairesRepository;

    public NoticeService(
        INoticesRepository noticesRepository, 
        IExemplairesRepository exemplairesRepository)
    {
        _noticesRepository = noticesRepository;
        _exemplairesRepository = exemplairesRepository;
    }

    // Sample method to demonstrate repository usage
    public async Task<Notice?> GetNoticeAsync(string cote)
    {
        return await _noticesRepository.GetQueryable()
            .Where(
                n => n.Cote == cote 
            ).FirstOrDefaultAsync();
    }
    public async Task<List<Exemplaire>> GetAvailableCopies(string cote)
    {
        return await _exemplairesRepository.GetQueryable()
                .Where(
                    e => e.Cote == cote && e.IdEtat == 1
                ).ToListAsync();
    }
    
}