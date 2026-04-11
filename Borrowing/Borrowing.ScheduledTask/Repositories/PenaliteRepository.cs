using Common.Models;
using Common.Data;
namespace Borrowing.ScheduledTask.Repositories;

internal interface IPenaliteRepository : IBaseRepository<Penalite>
{
}

internal sealed class  PenaliteRepository(LibraryDbContext context) : BaseRepository<Penalite>(context), IPenaliteRepository
{
}
