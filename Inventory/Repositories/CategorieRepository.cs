using Common.Models;

namespace Inventory.Repositories;
using Common.Data;
public interface ICategorieRepository : IBaseRepository<Categorie>
{
}
public class CategorieRepository : BaseRepository<Categorie>, ICategorieRepository
{
    public CategorieRepository(LibraryDbContext context) : base(context)
    {
    }
}
