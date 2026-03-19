using Shared.Data;
using Shared.Models;

namespace Borrowing.Api.Repositories;

public class PenaliteAdherentTempRepository : BaseRepository<PenaliteAdherentTemp>, IPenaliteAdherentTempRepository
{
    public PenaliteAdherentTempRepository(LibraryDbContext context) : base(context)
    {
    }
}
