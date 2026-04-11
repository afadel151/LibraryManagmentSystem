using Common.Models;

namespace Borrowing.Worker.Repositories;

internal interface IPenaliteRepository : IBaseRepository<Penalite>
{
}

internal class PenaliteRepository(LibraryDbContext context) : BaseRepository<Penalite>(context), IPenaliteRepository
{
}
