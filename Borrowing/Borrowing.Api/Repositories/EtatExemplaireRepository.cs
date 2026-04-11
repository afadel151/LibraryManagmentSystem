using Shared.Data;
using LibraryManagement.Common.Models;

namespace Borrowing.Api.Repositories;

public interface IEtatExemplaireRepository : IBaseRepository<EtatExemplaire>
{
}

public class EtatExemplaireRepository : BaseRepository<EtatExemplaire>, IEtatExemplaireRepository
{
    public EtatExemplaireRepository(LibraryDbContext context) : base(context)
    {
    }
}
