using Shared.Data;
using Shared.Models;

namespace Borrowing.Api.Repositories;

public class NoticesRepository : BaseRepository<Notice>, INoticesRepository
{
    public NoticesRepository(LibraryDbContext context) : base(context)
    {
    }
}
