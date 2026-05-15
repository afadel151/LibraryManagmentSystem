using Common.Models;
using Common.Data;
namespace Inventory.Repositories;

public interface IEditeurRepository : IBaseRepository<Editeur>
{
}
public class EditeurRepository(LibraryDbContext context) : BaseRepository<Editeur>(context), IEditeurRepository
{
}
