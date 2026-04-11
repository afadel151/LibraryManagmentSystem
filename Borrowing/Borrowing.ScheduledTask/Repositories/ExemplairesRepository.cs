using Common.Models;
using Common.Data;
namespace Borrowing.ScheduledTask.Repositories;

internal interface IExemplairesRepository : IBaseRepository<Exemplaire>
{
}

internal sealed class  ExemplairesRepository(LibraryDbContext context) : BaseRepository<Exemplaire>(context), IExemplairesRepository
{
}
