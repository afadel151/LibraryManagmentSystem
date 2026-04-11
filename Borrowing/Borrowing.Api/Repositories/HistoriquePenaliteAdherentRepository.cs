using Common.Models;

namespace Borrowing.Api.Repositories;

public interface IHistoriquePenaliteAdherentRepository : IBaseRepository<HistoriquePenaliteAdherent>
{
}

public class HistoriquePenaliteAdherentRepository : BaseRepository<HistoriquePenaliteAdherent>, IHistoriquePenaliteAdherentRepository
{
    public HistoriquePenaliteAdherentRepository(LibraryDbContext context) : base(context)
    {
    }
}
