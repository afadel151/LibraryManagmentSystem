using Common.Models;

namespace Borrowing.Worker.Repositories;

internal interface IHistoriquePenaliteAdherentRepository : IBaseRepository<HistoriquePenaliteAdherent>
{
}

internal sealed class  HistoriquePenaliteAdherentRepository(LibraryDbContext context) : BaseRepository<HistoriquePenaliteAdherent>(context), IHistoriquePenaliteAdherentRepository
{
}
