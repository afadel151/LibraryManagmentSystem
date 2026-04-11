using Common.Models;
using Common.Data;
namespace Borrowing.ScheduledTask.Repositories;
internal interface ICategorieRepository : IBaseRepository<Categorie>
{
}

internal class CategorieRepository(LibraryDbContext context) : BaseRepository<Categorie>(context), ICategorieRepository
{
}
