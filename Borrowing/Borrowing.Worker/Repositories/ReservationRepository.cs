using Common.Models;

namespace Borrowing.Worker.Repositories;
public interface IReservationRepository : IBaseRepository<Reservation>
{
}
public class ReservationRepository(LibraryDbContext context) : BaseRepository<Reservation>(context), IReservationRepository
{
}
