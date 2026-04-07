using Shared.Data;
using Shared.Models;

namespace Borrowing.Worker.Repositories;


public class PretRepository(LibraryDbContext context) : BaseRepository<Pret>(context)
{
}
