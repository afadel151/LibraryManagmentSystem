using Common.Models;
using Common.Data;
namespace Inventory.Repositories;

public interface IHistoriquePretRepository : IBaseRepository<HistoriquePret>
{
}
public class HistoriquePretRepository : BaseRepository<HistoriquePret>, IHistoriquePretRepository
{
    public HistoriquePretRepository(LibraryDbContext context) : base(context)
    {
    }
}
