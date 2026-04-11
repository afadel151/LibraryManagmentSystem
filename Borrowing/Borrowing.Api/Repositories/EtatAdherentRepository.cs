using Common.Models;

namespace Borrowing.Api.Repositories;
using Common.Data;
public interface IEtatAdherentRepository : IBaseRepository<EtatAdherent>
{
}

public class EtatAdherentRepository : BaseRepository<EtatAdherent>, IEtatAdherentRepository
{
    public EtatAdherentRepository(LibraryDbContext context) : base(context)
    {
    }
}
