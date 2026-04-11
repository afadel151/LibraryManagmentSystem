using Common.Models;
using Common.Data;
namespace Borrowing.ScheduledTask.Repositories;
internal interface IReservationRepository : IBaseRepository<Reservation>
{
}
internal class ReservationRepository(LibraryDbContext context) : BaseRepository<Reservation>(context), IReservationRepository
{
}
