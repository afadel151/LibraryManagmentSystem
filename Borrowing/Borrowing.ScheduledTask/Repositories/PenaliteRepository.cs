using Shared.Data;
using LibraryManagement.Common.Models;

namespace Borrowing.ScheduledTask.Repositories;

public interface IPenaliteRepository : IBaseRepository<Penalite>
{
}

public class PenaliteRepository(LibraryDbContext context) : BaseRepository<Penalite>(context), IPenaliteRepository
{
}
