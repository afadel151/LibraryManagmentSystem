using Shared.Data;
using Shared.Models;

namespace Borrowing.Worker.Repositories;


public class PenaliteAdherentRepository(LibraryDbContext context) : BaseRepository<PenaliteAdherent>(context)
{
}
