using Shared.Data;
using Shared.Models;

namespace Borrowing.ScheduledTask.Repositories;

public interface IPenaliteAdherentRepository : IBaseRepository<PenaliteAdherent>
{
}
public class PenaliteAdherentRepository(LibraryDbContext context) : BaseRepository<PenaliteAdherent>(context), IPenaliteAdherentRepository
{
}
