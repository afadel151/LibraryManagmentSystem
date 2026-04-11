using Common.Models;

namespace Borrowing.Worker.Repositories;

internal interface IPenaliteAdherentRepository : IBaseRepository<PenaliteAdherent>
{
}
internal class PenaliteAdherentRepository(LibraryDbContext context) : BaseRepository<PenaliteAdherent>(context), IPenaliteAdherentRepository
{
}
