using Shared.Data;
using Shared.Models;

namespace Borrowing.Worker.Repositories;

public class ReservationRepository(LibraryDbContext context) : BaseRepository<Reservation>(context)
{
}
