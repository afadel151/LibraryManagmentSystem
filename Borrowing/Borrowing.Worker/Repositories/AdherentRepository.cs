using Shared.Data;
using Shared.Models;

namespace Borrowing.Worker.Repositories;
public interface IAdherentRepository : IBaseRepository<Adherent>
{
}
public class AdherentRepository(LibraryDbContext context) : BaseRepository<Adherent>(context), IAdherentRepository
{
}
