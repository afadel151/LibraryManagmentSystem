using Common.Models;

namespace Borrowing.Worker.Repositories;
internal interface IReservationRepository : IBaseRepository<Reservation>
{
}
internal class ReservationRepository(LibraryDbContext context) : BaseRepository<Reservation>(context), IReservationRepository
{
}
