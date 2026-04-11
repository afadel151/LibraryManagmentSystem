using Common.Models;

namespace Borrowing.Api.Repositories;
using Common.Data;
public interface IEtatExemplaireRepository : IBaseRepository<EtatExemplaire>
{
}

public class EtatExemplaireRepository : BaseRepository<EtatExemplaire>, IEtatExemplaireRepository
{
    public EtatExemplaireRepository(LibraryDbContext context) : base(context)
    {
    }
}
