using Shared.Data;
using LibraryManagement.Common.Models;

namespace Borrowing.Api.Repositories;

public interface IPenaliteAdherentTempRepository : IBaseRepository<PenaliteAdherentTemp>
{
}

public class PenaliteAdherentTempRepository : BaseRepository<PenaliteAdherentTemp>, IPenaliteAdherentTempRepository
{
    public PenaliteAdherentTempRepository(LibraryDbContext context) : base(context)
    {
    }
}
