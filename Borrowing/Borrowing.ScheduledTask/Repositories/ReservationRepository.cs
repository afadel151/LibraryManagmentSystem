using Shared.Data;
using LibraryManagement.Shared.Models;

namespace Borrowing.ScheduledTask.Repositories;
public interface IReservationRepository : IBaseRepository<Reservation>
{
}
public class ReservationRepository(LibraryDbContext context) : BaseRepository<Reservation>(context), IReservationRepository
{
}
