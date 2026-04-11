using Common.Models;

namespace Borrowing.Worker.Repositories;

internal interface IExemplairesRepository : IBaseRepository<Exemplaire>
{
}

internal sealed class  ExemplairesRepository(LibraryDbContext context) : BaseRepository<Exemplaire>(context), IExemplairesRepository
{
}
