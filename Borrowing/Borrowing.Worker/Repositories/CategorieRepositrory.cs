using Shared.Data;
using Shared.Models;

namespace Borrowing.Worker.Repositories;


public class CategorieRepository(LibraryDbContext context) : BaseRepository<Categorie>(context)
{
}
