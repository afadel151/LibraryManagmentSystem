using Common.Models;

namespace Borrowing.Worker.Repositories;

internal interface IPenaliteRepository : IBaseRepository<Penalite>
{
}

internal sealed class  PenaliteRepository(LibraryDbContext context) : BaseRepository<Penalite>(context), IPenaliteRepository
{
}
