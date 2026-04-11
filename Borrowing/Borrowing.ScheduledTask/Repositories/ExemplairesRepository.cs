using Shared.Data;
using LibraryManagement.Shared.Models;

namespace Borrowing.ScheduledTask.Repositories;

public interface IExemplairesRepository : IBaseRepository<Exemplaire>
{
}

public class ExemplairesRepository(LibraryDbContext context) : BaseRepository<Exemplaire>(context), IExemplairesRepository
{
}
