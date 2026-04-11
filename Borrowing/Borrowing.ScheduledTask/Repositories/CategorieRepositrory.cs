using Common.Models;
using Common.Data;
namespace Borrowing.ScheduledTask.Repositories;
public interface ICategorieRepository : IBaseRepository<Categorie>
{
}

public class CategorieRepository(LibraryDbContext context) : BaseRepository<Categorie>(context), ICategorieRepository
{
}
