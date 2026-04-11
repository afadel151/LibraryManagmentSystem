using Common.Models;

namespace Borrowing.Worker.Repositories;

internal interface IJoursFeriesRepository : IBaseRepository<JoursFery>
{
}
internal sealed class  JoursFeriesRepository(LibraryDbContext context) : BaseRepository<JoursFery>(context), IJoursFeriesRepository
{
}
