using Common.Models;

namespace Borrowing.Worker.Repositories;

internal interface IPretRepository : IBaseRepository<Pret>
{
}
internal class PretRepository(LibraryDbContext context) : BaseRepository<Pret>(context), IPretRepository
{
}
