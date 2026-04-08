using Shared.Data;
using Shared.Models;

namespace Borrowing.Worker.Repositories;

public interface IHistoriquePenaliteAdherentRepository : IBaseRepository<HistoriquePenaliteAdherent>
{
}

public class HistoriquePenaliteAdherentRepository(LibraryDbContext context) : BaseRepository<HistoriquePenaliteAdherent>(context), IHistoriquePenaliteAdherentRepository
{
}
