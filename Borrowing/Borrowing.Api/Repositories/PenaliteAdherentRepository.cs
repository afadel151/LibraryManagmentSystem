using Shared.Data;
using LibraryManagement.Shared.Models;

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
