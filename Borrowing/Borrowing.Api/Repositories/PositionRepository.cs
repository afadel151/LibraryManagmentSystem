using Shared.Data;
using Shared.Models;

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
