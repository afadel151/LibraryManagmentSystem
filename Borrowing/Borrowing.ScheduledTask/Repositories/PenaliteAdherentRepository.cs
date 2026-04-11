using Common.Models;
using Common.Data;
namespace Borrowing.ScheduledTask.Repositories;

internal interface IPenaliteAdherentRepository : IBaseRepository<PenaliteAdherent>
{
}
internal sealed class  PenaliteAdherentRepository(LibraryDbContext context) : BaseRepository<PenaliteAdherent>(context), IPenaliteAdherentRepository
{
}
