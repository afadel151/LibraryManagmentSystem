using Common.Data;
using Common.Models;

namespace Borrowing.ScheduledTask.Repositories;
internal interface IAdherentRepository : IBaseRepository<Adherent>
{
}
internal sealed class  AdherentRepository(LibraryDbContext context) : BaseRepository<Adherent>(context), IAdherentRepository
{
}
