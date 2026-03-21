using Shared.Data;
using Shared.Models;

namespace Borrowing.Api.Repositories;

public interface IHistoriquePretRepository : IBaseRepository<HistoriquePret>
{
}
public class HistoriquePretRepository : BaseRepository<HistoriquePret>, IHistoriquePretRepository
{
    public HistoriquePretRepository(LibraryDbContext context) : base(context)
    {
    }
}
