using Common.Models;

namespace Borrowing.Worker.Repositories;
internal interface IAdherentRepository : IBaseRepository<Adherent>
{
}
internal sealed class  AdherentRepository(LibraryDbContext context) : BaseRepository<Adherent>(context), IAdherentRepository
{
}
