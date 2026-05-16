using Common.Models;
using Inventory.Models.Catalogue;
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
  



    public async Task<IEnumerable<Periodicite>> GetPeriodicites()
    {
        return await periodiciteRepository.GetAllAsync();
    }

    public async Task<IEnumerable<Fonction>> GetFonctions()
    {
        return await fonctionRepository.GetAllAsync();
    }

    public async Task<IEnumerable<Pay>> GetPays()
    {
        return await paysRepository.GetAllAsync();
    }

   
}
