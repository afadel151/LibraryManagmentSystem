using Shared.Data;
using Shared.Models;

namespace Borrowing.Api.Repositories;

public class PenaliteRepository : BaseRepository<Penalite>, IPenaliteRepository
{
    public PenaliteRepository(LibraryDbContext context) : base(context)
    {
    }
}
