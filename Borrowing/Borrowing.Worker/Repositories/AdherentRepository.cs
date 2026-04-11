using Shared.Data;
using LibraryManagement.Common.Models;

namespace Borrowing.Worker.Repositories;
public interface IAdherentRepository : IBaseRepository<Adherent>
{
}
public class AdherentRepository(LibraryDbContext context) : BaseRepository<Adherent>(context), IAdherentRepository
{
}
