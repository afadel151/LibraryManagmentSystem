using Shared.Data;
using Shared.Models;

namespace Borrowing.Worker.Repositories;

public class AdherentRepository(LibraryDbContext context) : BaseRepository<Adherent>(context)
{
}
