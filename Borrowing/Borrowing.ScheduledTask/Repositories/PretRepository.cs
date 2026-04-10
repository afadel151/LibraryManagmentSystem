using Shared.Data;
using Shared.Models;

namespace Borrowing.ScheduledTask.Repositories;

public interface IPretRepository : IBaseRepository<Pret>
{
}
public class PretRepository(LibraryDbContext context) : BaseRepository<Pret>(context), IPretRepository
{
}
