using Shared.Data;
using Shared.Models;

namespace Borrowing.Api.Repositories;

public class PretRepository : BaseRepository<Pret>, IPretRepository
{
    public PretRepository(LibraryDbContext context) : base(context)
    {
    }
}
