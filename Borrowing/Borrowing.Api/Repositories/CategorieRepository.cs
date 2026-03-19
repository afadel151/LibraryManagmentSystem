using Shared.Data;
using Shared.Models;

namespace Borrowing.Api.Repositories;

public class CategorieRepository : BaseRepository<Categorie>, ICategorieRepository
{
    public CategorieRepository(LibraryDbContext context) : base(context)
    {
    }
}
