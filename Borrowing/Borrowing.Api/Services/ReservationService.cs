using Borrowing.Api.Repositories;
using Microsoft.EntityFrameworkCore;
using Shared.Models;

namespace Borrowing.Api.Services;

public interface IReservationService
{
    Task<Reservation?> CreateReservationAsync(Reservation reservation);
    Task<int> CountAsync();
    Task<List<Reservation>> GetAllDescByHeur(int n);
    Task<List<Reservation>> GetAllDescByHeur();
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

    public async Task<bool?> CheckAdherentReservingCote(string AdherentId,string cote)
    {
        int count = await _reservationRepository.GetQueryable()
                .Where(
                    r => r.IdAdherent == AdherentId && r.Cote == cote
                ).CountAsync();
        return count > 0;
    }
    public async Task<int> CountAsync()
    {
        return await _reservationRepository.GetQueryable().CountAsync();
    }

    public async Task<List<Reservation>> GetAllDescByHeur(int n)
    {
        return await _reservationRepository.GetQueryable()
                        .OrderByDescending(p => p.HeureReservation)
                        .Take(n)
                        .ToListAsync();                   
    }
     public async Task<List<Reservation>> GetAllDescByHeur()
    {
        return await _reservationRepository.GetQueryable()
                        .OrderByDescending(p => p.HeureReservation)
                        .ToListAsync();                   
    }
}