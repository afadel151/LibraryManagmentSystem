using Shared.Data;
using Shared.Models;

namespace Borrowing.Api.Repositories;

public class HistoriquePenaliteAdherentRepository : BaseRepository<HistoriquePenaliteAdherent>, IHistoriquePenaliteAdherentRepository
{
    public HistoriquePenaliteAdherentRepository(LibraryDbContext context) : base(context)
    {
    }
}
