using Common.Models;

namespace Borrowing.Api.Repositories;
using Common.Data;
public interface IExemplairesRepository : IBaseRepository<Exemplaire>
{
}

public class ExemplairesRepository : BaseRepository<Exemplaire>, IExemplairesRepository
{
    public ExemplairesRepository(LibraryDbContext context) : base(context)
    {
    }
}
