using Shared.Data;
using LibraryManagement.Shared.Models;

namespace Borrowing.Api.Repositories;

public interface IPenaliteRepository : IBaseRepository<Penalite>
{
}

public class PenaliteRepository : BaseRepository<Penalite>, IPenaliteRepository
{
    public PenaliteRepository(LibraryDbContext context) : base(context)
    {
    }
}
