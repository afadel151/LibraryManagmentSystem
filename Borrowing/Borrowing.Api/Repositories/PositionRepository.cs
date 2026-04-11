using Common.Models;
using Common.Data;
namespace Borrowing.Api.Repositories;
public interface IPositionRepository : IBaseRepository<Position>
{    
}

public class PositionRepository : BaseRepository<Position>, IPositionRepository
{
    public PositionRepository(LibraryDbContext context) : base(context)
    {
    }
}
