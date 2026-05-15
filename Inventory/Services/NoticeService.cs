using Common.Models;
using Inventory.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Inventory.Services;

public interface INoticeService
{
    Task<IEnumerable<Periodicite>> GetPeriodicites();
    Task<IEnumerable<Fonction>> GetFonctions();
    Task<IEnumerable<Pay>> GetPays();
}

public class NoticeService(
    INoticeRepository noticeReporitory,
    IPeriodiciteRepository periodiciteRepository,
    IFonctionRepository fonctionRepository,
    IPaysRepository paysRepository
) : INoticeService
{
    private readonly INoticeRepository _noticeReporitory = noticeReporitory;    
    private readonly IPeriodiciteRepository _periodiciteReporitory = periodiciteRepository;    
    private readonly IFonctionRepository _fonctionReporitory = fonctionRepository;    
    private readonly IPaysRepository _paysReporitory = paysRepository;    



    public async Task<IEnumerable<Periodicite>> GetPeriodicites()
    {
        return await _periodiciteReporitory.GetAllAsync();
    }

    public async Task<IEnumerable<Fonction>> GetFonctions()
    {
        return await _fonctionReporitory.GetAllAsync();
    }

    public async Task<IEnumerable<Pay>> GetPays()
    {
        return await _paysReporitory.GetAllAsync();
    }
}
