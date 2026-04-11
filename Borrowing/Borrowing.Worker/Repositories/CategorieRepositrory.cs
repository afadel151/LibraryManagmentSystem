using Shared.Data;
using LibraryManagement.Shared.Models;

namespace Borrowing.Worker.Repositories;
public interface ICategorieRepository : IBaseRepository<Categorie>
{
}

public class CategorieRepository(LibraryDbContext context) : BaseRepository<Categorie>(context), ICategorieRepository
{
}
