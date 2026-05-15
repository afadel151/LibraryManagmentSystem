using Common.Models;

namespace Inventory.Repositories;
using Common.Data;
public interface IExemplaireRepository : IBaseRepository<Exemplaire>
{
}

public class ExemplaireRepository : BaseRepository<Exemplaire>, IExemplaireRepository
{
    public ExemplaireRepository(LibraryDbContext context) : base(context)
    {
    }
}
