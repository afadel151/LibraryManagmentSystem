using Common.Models;
using Common.Data;
namespace Borrowing.Api.Repositories;
public interface IPenaliteAdherentRepository : IBaseRepository<PenaliteAdherent>
{
}

public class PenaliteAdherentRepository : BaseRepository<PenaliteAdherent>, IPenaliteAdherentRepository
{
    public PenaliteAdherentRepository(LibraryDbContext context) : base(context)
    {
    }
}
