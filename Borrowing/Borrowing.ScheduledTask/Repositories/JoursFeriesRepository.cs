using Common.Models;
using Common.Data;
namespace Borrowing.ScheduledTask.Repositories;

internal interface IJoursFeriesRepository : IBaseRepository<JoursFery>
{
}
internal sealed class  JoursFeriesRepository(LibraryDbContext context) : BaseRepository<JoursFery>(context), IJoursFeriesRepository
{
}
