using Common.Models;
using Common.Data;
namespace Inventory.Repositories;

public interface IDiplomeRepository : IBaseRepository<Diplome>
{
}
public class DiplomeRepository(LibraryDbContext context) : BaseRepository<Diplome>(context), IDiplomeRepository
{
}
