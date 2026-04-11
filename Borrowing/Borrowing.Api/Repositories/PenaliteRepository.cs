using Common.Models;
using Common.Data;
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
