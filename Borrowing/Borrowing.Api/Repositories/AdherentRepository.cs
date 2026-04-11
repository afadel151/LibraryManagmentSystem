using Common.Models;

namespace Borrowing.Api.Repositories;
using Common.Data;
public interface IAdherentRepository : IBaseRepository<Adherent>
{
}
public class AdherentRepository : BaseRepository<Adherent>, IAdherentRepository
{
    public AdherentRepository(LibraryDbContext context) : base(context)
    {
    }
}
