using Common.Models;
using Common.Data;
namespace Inventory.Repositories;

public interface IThemeRepository : IBaseRepository<Theme>
{
}
public class ThemeRepository(LibraryDbContext context) : BaseRepository<Theme>(context), IThemeRepository
{
}
