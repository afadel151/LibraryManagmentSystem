using Common.Models;

namespace Borrowing.Api.Repositories;
using Common.Data;
public interface IHistoriquePenaliteAdherentRepository : IBaseRepository<HistoriquePenaliteAdherent>
{
}

public class HistoriquePenaliteAdherentRepository : BaseRepository<HistoriquePenaliteAdherent>, IHistoriquePenaliteAdherentRepository
{
    public HistoriquePenaliteAdherentRepository(LibraryDbContext context) : base(context)
    {
    }
}
