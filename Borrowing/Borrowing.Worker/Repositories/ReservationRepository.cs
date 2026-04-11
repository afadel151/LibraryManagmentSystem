using Common.Models;

namespace Borrowing.Worker.Repositories;
internal interface IReservationRepository : IBaseRepository<Reservation>
{
}
internal sealed class  ReservationRepository(LibraryDbContext context) : BaseRepository<Reservation>(context), IReservationRepository
{
}
