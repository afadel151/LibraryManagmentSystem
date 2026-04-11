using Common.Models;

namespace Borrowing.Worker.Repositories;

internal interface IPretRepository : IBaseRepository<Pret>
{
}
internal sealed class  PretRepository(LibraryDbContext context) : BaseRepository<Pret>(context), IPretRepository
{
}
