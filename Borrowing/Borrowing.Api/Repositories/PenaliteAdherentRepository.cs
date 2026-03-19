using Shared.Data;
using Shared.Models;

namespace Borrowing.Api.Repositories;

public class PenaliteAdherentRepository : BaseRepository<PenaliteAdherent>, IPenaliteAdherentRepository
{
    public PenaliteAdherentRepository(LibraryDbContext context) : base(context)
    {
    }
}
