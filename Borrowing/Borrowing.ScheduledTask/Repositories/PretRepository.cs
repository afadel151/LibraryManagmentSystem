using Common.Models;
using Common.Data;
namespace Borrowing.ScheduledTask.Repositories;

internal interface IPretRepository : IBaseRepository<Pret>
{
}
internal class PretRepository(LibraryDbContext context) : BaseRepository<Pret>(context), IPretRepository
{
}
