using Shared.Data;
using LibraryManagement.Common.Models;

namespace Borrowing.Worker.Repositories;

public interface IPenaliteRepository : IBaseRepository<Penalite>
{
}

public class PenaliteRepository(LibraryDbContext context) : BaseRepository<Penalite>(context), IPenaliteRepository
{
}
