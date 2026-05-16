using Common.Models;
using Common.Data;
namespace Inventory.Repositories;

public interface ILangueRepository : IBaseRepository<Langue>
{
}
public class LangueRepository(LibraryDbContext context) : BaseRepository<Langue>(context), ILangueRepository
{
}
