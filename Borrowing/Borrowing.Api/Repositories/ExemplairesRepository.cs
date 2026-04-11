using Shared.Data;
using LibraryManagement.Shared.Models;

namespace Borrowing.Api.Repositories;

public interface IExemplairesRepository : IBaseRepository<Exemplaire>
{
}

public class ExemplairesRepository : BaseRepository<Exemplaire>, IExemplairesRepository
{
    public ExemplairesRepository(LibraryDbContext context) : base(context)
    {
    }
}
