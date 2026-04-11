using Common.Models;
using Common.Data;
namespace Borrowing.ScheduledTask.Repositories;

public interface IExemplairesRepository : IBaseRepository<Exemplaire>
{
}

public class ExemplairesRepository(LibraryDbContext context) : BaseRepository<Exemplaire>(context), IExemplairesRepository
{
}
