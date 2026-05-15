using Common.Models;
using Common.Data;
namespace Inventory.Repositories;

public interface IMotsCleRepository : IBaseRepository<MotsCle>
{
}
public class MotsCleRepository(LibraryDbContext context) : BaseRepository<MotsCle>(context), IMotsCleRepository
{
}
