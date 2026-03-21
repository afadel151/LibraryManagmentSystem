using Shared.Data;
using Shared.Models;

namespace Borrowing.Api.Repositories;

public interface IJoursFeriesRepository : IBaseRepository<JoursFery>
{
}
public class JoursFeriesRepository : BaseRepository<JoursFery>, IJoursFeriesRepository
{
    public JoursFeriesRepository(LibraryDbContext context) : base(context)
    {
    }
}
