using Shared.Data;
using Shared.Models;

namespace Borrowing.Api.Repositories;

public interface IEtatAdherentRepository : IBaseRepository<EtatAdherent>
{
}

public class EtatAdherentRepository : BaseRepository<EtatAdherent>, IEtatAdherentRepository
{
    public EtatAdherentRepository(LibraryDbContext context) : base(context)
    {
    }
}
