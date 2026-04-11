using Common.Models;
using Common.Data;
namespace Borrowing.ScheduledTask.Repositories;

public interface IJoursFeriesRepository : IBaseRepository<JoursFery>
{
}
public class JoursFeriesRepository(LibraryDbContext context) : BaseRepository<JoursFery>(context), IJoursFeriesRepository
{
}
