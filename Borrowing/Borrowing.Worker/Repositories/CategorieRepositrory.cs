using Common.Models;

namespace Borrowing.Worker.Repositories;
internal interface ICategorieRepository : IBaseRepository<Categorie>
{
}

internal class CategorieRepository(LibraryDbContext context) : BaseRepository<Categorie>(context), ICategorieRepository
{
}
