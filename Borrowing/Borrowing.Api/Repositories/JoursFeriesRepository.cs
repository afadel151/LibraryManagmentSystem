using Shared.Data;
using LibraryManagement.Shared.Models;

namespace Borrowing.Api.Repositories;

public interface IJoursFeriesRepository : IBaseRepository<JoursFery>
{
}
public class JoursFeriesRepository(LibraryDbContext context) : BaseRepository<JoursFery>(context), IJoursFeriesRepository
{
}
