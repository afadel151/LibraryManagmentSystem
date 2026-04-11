using Common.Models;
using Common.Data;

namespace Borrowing.ScheduledTask.Repositories;

internal interface IHistoriquePenaliteAdherentRepository : IBaseRepository<HistoriquePenaliteAdherent>
{
}

internal sealed class  HistoriquePenaliteAdherentRepository(LibraryDbContext context) : BaseRepository<HistoriquePenaliteAdherent>(context), IHistoriquePenaliteAdherentRepository
{
}
