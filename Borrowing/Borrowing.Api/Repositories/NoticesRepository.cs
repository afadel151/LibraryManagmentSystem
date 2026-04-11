using Shared.Data;
using LibraryManagement.Shared.Models;

namespace Borrowing.Api.Repositories;

public interface INoticesRepository : IBaseRepository<Notice>
{
}
public class NoticesRepository : BaseRepository<Notice>, INoticesRepository
{
    public NoticesRepository(LibraryDbContext context) : base(context)
    {
    }
}
