using Borrowing.Api.Repositories;
using Shared.Models;

namespace Borrowing.Api.Services;

public interface IReservationService
{
    Task<Reservation?> CreateReservationAsync(Reservation reservation);
}

public class ReservationService : IReservationService
{
    private readonly IReservationRepository _reservationRepository;
    private readonly IAdherentRepository _adherentRepository;
    private readonly INoticesRepository _noticesRepository;
    private readonly IExemplairesRepository _exemplairesRepository;

    public ReservationService(
        IReservationRepository reservationRepository,
        IAdherentRepository adherentRepository,
        INoticesRepository noticesRepository,
        IExemplairesRepository exemplairesRepository)
    {
        _reservationRepository = reservationRepository;
        _adherentRepository = adherentRepository;
        _noticesRepository = noticesRepository;
        _exemplairesRepository = exemplairesRepository;
    }

    // Sample method to demonstrate repository usage
    public async Task<Reservation?> CreateReservationAsync(Reservation reservation)
    {
        // Example: save a reservation
        await _reservationRepository.AddAsync(reservation);
        return reservation;
    }
}