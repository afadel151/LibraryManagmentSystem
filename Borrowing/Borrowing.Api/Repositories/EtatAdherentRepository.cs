using Shared.Data;
using LibraryManagement.Common.Models;

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
