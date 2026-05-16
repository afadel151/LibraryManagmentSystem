using Common.Models;
using Common.Data;
namespace Inventory.Repositories;

public interface IDisciplineRepository : IBaseRepository<Discipline>
{
}
public class DisciplineRepository(LibraryDbContext context) : BaseRepository<Discipline>(context), IDisciplineRepository
{
}
