using Common.Models;
using Common.Data;
namespace Borrowing.ScheduledTask.Repositories;
public interface IReservationRepository : IBaseRepository<Reservation>
{
}
public class ReservationRepository(LibraryDbContext context) : BaseRepository<Reservation>(context), IReservationRepository
{
}
