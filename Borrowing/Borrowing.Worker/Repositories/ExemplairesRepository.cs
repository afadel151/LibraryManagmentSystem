using Shared.Data;
using Shared.Models;

namespace Borrowing.Worker.Repositories;



public class ExemplairesRepository(LibraryDbContext context) : BaseRepository<Exemplaire>(context)
{
}
