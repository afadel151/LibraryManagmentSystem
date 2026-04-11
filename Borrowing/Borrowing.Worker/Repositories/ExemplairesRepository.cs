using Common.Models;

namespace Borrowing.Worker.Repositories;

public interface IExemplairesRepository : IBaseRepository<Exemplaire>
{
}

public class ExemplairesRepository(LibraryDbContext context) : BaseRepository<Exemplaire>(context), IExemplairesRepository
{
}
