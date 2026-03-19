using Shared.Data;
using Shared.Models;

namespace Borrowing.Api.Repositories;

public class JoursFeriesRepository : BaseRepository<JoursFery>, IJoursFeriesRepository
{
    public JoursFeriesRepository(LibraryDbContext context) : base(context)
    {
    }
}
