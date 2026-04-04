using Borrowing.Api.Repositories;
using Borrowing.SharedClasses.Common;
using Borrowing.SharedClasses.Requests.Reservation;
using Microsoft.EntityFrameworkCore;
using Shared.Models;

namespace Borrowing.Api.Services;

public interface IReservationService
{
    Task<Reservation?> CreateReservationAsync(CreateReservationRequestDto reservation);
    Task<PagedResult<ReservationDto>> GetPaginated(PaginatedQueryParameters queryParameters);
    Task<int> CountAsync();
    Task<bool> CheckAdherentReservingCote(string AdherentId, string cote);
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
    public async Task<Reservation?> CreateReservationAsync(CreateReservationRequestDto reservation)
    {
        // Example: save a reservation
        Reservation res = new()
        {
            IdAdherent = reservation.AdherentId,
            Cote = reservation.Cote,
            HeureReservation = DateTime.Now
        };
        try
        {
            await _reservationRepository.AddAsync(res);
            return res;
        }
        catch (System.Exception)
        {
            return null;
        }
    }

    public async Task<bool> CheckAdherentReservingCote(string AdherentId, string cote)
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

    public async Task<PagedResult<ReservationDto>> GetPaginated(PaginatedQueryParameters queryParameters)
    {
        var reservations = _reservationRepository.GetQueryable()
                            .Include(r => r.Adherent);

        var notices = _noticesRepository.GetQueryable();

        var query = from r in reservations
                    join n in notices on r.Cote equals n.Cote
                    select new ReservationDto
                    {
                        IdAdherent = r.IdAdherent,
                        Cote = r.Cote,
                        HeureReservation = r.HeureReservation,
                        Nom = r.Adherent.Nom!,
                        Prenom = r.Adherent.Prenom!,
                        TitrePropre = n.TitrePropre!,
                    };
        if (!string.IsNullOrWhiteSpace(queryParameters.Search))
        {
            var search = queryParameters.Search.ToLower(); // only once, on the in-memory value
            query = query.Where(x =>
                x.IdAdherent.ToLower().Contains(search) ||
                x.Nom!.ToLower().Contains(search) ||
                x.Prenom!.ToLower().Contains(search) ||
                x.Cote.ToLower().Contains(search) ||
                x.TitrePropre!.ToLower().Contains(search));
        }
        if (!string.IsNullOrEmpty(queryParameters.OrderBy))
        {
            query = queryParameters.OrderBy.ToLower() switch
            {
                "cote asc" => query.OrderBy(x => x.Cote),
                "cote desc" => query.OrderByDescending(x => x.Cote),

                "titrepropre asc" => query.OrderBy(x => x.TitrePropre),
                "titrepropre desc" => query.OrderByDescending(x => x.TitrePropre),


                "nom asc" => query.OrderBy(x => x.Nom),
                "nom desc" => query.OrderByDescending(x => x.Nom),

                "prenom asc" => query.OrderBy(x => x.Prenom),
                "prenom desc" => query.OrderByDescending(x => x.Prenom),

                "idadherent asc" => query.OrderBy(x => x.IdAdherent),
                "idadherent desc" => query.OrderByDescending(x => x.IdAdherent),


                "heurereservation asc" => query.OrderBy(x => x.HeureReservation),
                "heurereservation desc" => query.OrderByDescending(x => x.HeureReservation),

                _ => query.OrderByDescending(x => x.HeureReservation)
            };
        }
        else
        {
            query = query.OrderByDescending(x => x.HeureReservation); // Default orderin
        }
        var totalCount = await query.CountAsync();

        var data = await query
            .Skip((queryParameters.PageNumber - 1) * queryParameters.PageSize)
            .Take(queryParameters.PageSize)
            .ToListAsync();


        return new PagedResult<ReservationDto>
        {
            Data = data,
            TotalCount = totalCount,
            PageNumber = queryParameters.PageNumber,
            PageSize = queryParameters.PageSize
        };

    }
}