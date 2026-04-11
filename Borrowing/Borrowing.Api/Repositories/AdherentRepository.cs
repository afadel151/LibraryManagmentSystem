using Common.Models;

namespace Borrowing.Api.Repositories;

public interface IAdherentRepository : IBaseRepository<Adherent>
{
}
public class AdherentRepository : BaseRepository<Adherent>, IAdherentRepository
{
    public AdherentRepository(LibraryDbContext context) : base(context)
    {
    }
}
