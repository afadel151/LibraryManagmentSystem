using Shared.Data;
using LibraryManagement.Common.Models;

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
