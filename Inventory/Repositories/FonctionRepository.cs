using Common.Models;

namespace Inventory.Repositories;
using Common.Data;
public interface IFonctionRepository : IBaseRepository<Fonction>
{
}

public class FonctionRepository(LibraryDbContext context) : BaseRepository<Fonction>(context), IFonctionRepository
{
}
