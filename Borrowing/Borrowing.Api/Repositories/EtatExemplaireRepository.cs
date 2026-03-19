using Shared.Data;
using Shared.Models;

namespace Borrowing.Api.Repositories;

public class EtatExemplaireRepository : BaseRepository<EtatExemplaire>, IEtatExemplaireRepository
{
    public EtatExemplaireRepository(LibraryDbContext context) : base(context)
    {
    }
}
