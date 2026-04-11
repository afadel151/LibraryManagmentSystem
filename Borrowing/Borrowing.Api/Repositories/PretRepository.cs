using Shared.Data;
using LibraryManagement.Shared.Models;

namespace Borrowing.Api.Repositories;

public interface IPretRepository : IBaseRepository<Pret>
{
}
public class PretRepository : BaseRepository<Pret>, IPretRepository
{
    public PretRepository(LibraryDbContext context) : base(context)
    {
    }
}
