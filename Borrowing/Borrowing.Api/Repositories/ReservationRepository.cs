using Shared.Data;
using Shared.Models;

namespace Borrowing.Api.Repositories;
public interface IReservationRepository : IBaseRepository<Reservation>
{
}

public class ReservationRepository : BaseRepository<Reservation>, IReservationRepository
{
    public ReservationRepository(LibraryDbContext context) : base(context)
    {
    }
}
