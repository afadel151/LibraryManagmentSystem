using Shared.Data;
using LibraryManagement.Common.Models;

namespace Borrowing.Worker.Repositories;

public interface IPenaliteAdherentRepository : IBaseRepository<PenaliteAdherent>
{
}
public class PenaliteAdherentRepository(LibraryDbContext context) : BaseRepository<PenaliteAdherent>(context), IPenaliteAdherentRepository
{
}
