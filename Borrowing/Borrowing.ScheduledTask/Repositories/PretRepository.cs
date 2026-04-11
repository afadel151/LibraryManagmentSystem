using Shared.Data;
using LibraryManagement.Common.Models;

namespace Borrowing.ScheduledTask.Repositories;

public interface IPretRepository : IBaseRepository<Pret>
{
}
public class PretRepository(LibraryDbContext context) : BaseRepository<Pret>(context), IPretRepository
{
}
