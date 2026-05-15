using Common.Models;
using Common.Data;
namespace Inventory.Repositories;

public interface IVilleRepository : IBaseRepository<Ville>
{
}
public class VilleRepository(LibraryDbContext context) : BaseRepository<Ville>(context), IVilleRepository
{
}
