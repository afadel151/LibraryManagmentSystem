using Shared.Data;
using Shared.Models;

namespace Borrowing.Worker.Repositories;


public class PenaliteRepository(LibraryDbContext context) : BaseRepository<Penalite>(context)
{
}
