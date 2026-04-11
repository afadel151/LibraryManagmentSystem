using Shared.Data;
using LibraryManagement.Shared.Models;

namespace Borrowing.ScheduledTask.Repositories;
public interface IAdherentRepository : IBaseRepository<Adherent>
{
}
public class AdherentRepository(LibraryDbContext context) : BaseRepository<Adherent>(context), IAdherentRepository
{
}
