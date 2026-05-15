using Common.Models;
using Common.Data;
namespace Inventory.Repositories;

public interface IPaysRepository : IBaseRepository<Pay>
{
}
public class PaysRepository(LibraryDbContext context) : BaseRepository<Pay>(context), IPaysRepository
{
}
