using Shared.Data;
using Shared.Models;

namespace Borrowing.Api.Repositories;

public class ReservationRepository : BaseRepository<Reservation>, IReservationRepository
{
    public ReservationRepository(LibraryDbContext context) : base(context)
    {
    }
}
