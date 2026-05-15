using Common.Models;
using Common.Data;
namespace Inventory.Repositories;

public interface IJoursFeriesRepository : IBaseRepository<JoursFery>
{
}
public class JoursFeriesRepository(LibraryDbContext context) : BaseRepository<JoursFery>(context), IJoursFeriesRepository
{
}
