using Common.Models;
using Common.Data;
namespace Borrowing.ScheduledTask.Repositories;

internal interface IPretRepository : IBaseRepository<Pret>
{
}
internal sealed class  PretRepository(LibraryDbContext context) : BaseRepository<Pret>(context), IPretRepository
{
}
