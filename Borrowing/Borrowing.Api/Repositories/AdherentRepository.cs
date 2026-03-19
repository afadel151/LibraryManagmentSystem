using Shared.Data;
using Shared.Models;

namespace Borrowing.Api.Repositories;

public class AdherentRepository : BaseRepository<Adherent>, IAdherentRepository
{
    public AdherentRepository(LibraryDbContext context) : base(context)
    {
    }
}
