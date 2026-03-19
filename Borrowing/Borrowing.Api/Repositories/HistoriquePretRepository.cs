using Shared.Data;
using Shared.Models;

namespace Borrowing.Api.Repositories;

public class HistoriquePretRepository : BaseRepository<HistoriquePret>, IHistoriquePretRepository
{
    public HistoriquePretRepository(LibraryDbContext context) : base(context)
    {
    }
}
