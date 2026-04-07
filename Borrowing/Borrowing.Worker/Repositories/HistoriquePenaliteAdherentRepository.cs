using Shared.Data;
using Shared.Models;

namespace Borrowing.Worker.Repositories;



public class HistoriquePenaliteAdherentRepository(LibraryDbContext context) : BaseRepository<HistoriquePenaliteAdherent>(context)
{
}
