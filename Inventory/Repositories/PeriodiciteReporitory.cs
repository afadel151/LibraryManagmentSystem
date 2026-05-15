using Common.Models;
using Common.Data;
namespace Inventory.Repositories;
public interface IPeriodiciteRepository : IBaseRepository<Periodicite>
{    
}

public class PeriodiciteRepository : BaseRepository<Periodicite>, IPeriodiciteRepository
{
    public PeriodiciteRepository(LibraryDbContext context) : base(context)
    {
    }
}
