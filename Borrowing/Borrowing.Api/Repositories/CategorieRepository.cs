using Shared.Data;
using Shared.Models;

namespace Borrowing.Api.Repositories;

public interface ICategorieRepository : IBaseRepository<Categorie>
{
}
public class CategorieRepository : BaseRepository<Categorie>, ICategorieRepository
{
    public CategorieRepository(LibraryDbContext context) : base(context)
    {
    }
}
