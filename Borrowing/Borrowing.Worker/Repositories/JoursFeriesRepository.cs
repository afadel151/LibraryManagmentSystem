using Shared.Data;
using Shared.Models;

namespace Borrowing.Worker.Repositories;


public class JoursFeriesRepository(LibraryDbContext context) : BaseRepository<JoursFery>(context)
{
}
