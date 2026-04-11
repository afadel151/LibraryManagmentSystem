using Borrowing.Api.Repositories;
using Borrowing.SharedClasses.Models;
using Borrowing.SharedClasses.Requests.Reservation;
using Microsoft.EntityFrameworkCore;
using Common.Models;

namespace Borrowing.Api.Services;

public interface IReservationService
{
    Task<Reservation?> CreateReservationAsync(CreateReservationRequestDto reservation);
    Task<PagedResult<ReservationDto>> GetPaginated(PaginatedQueryParameters queryParameters);
    Task<int> CountAsync();
    Task<bool> CheckAdherentReservingCote(string AdherentId, string cote);
    Task<List<Reservation>> GetAllDescByHeur(int n);
    Task<List<RelanceDto>> GetRelances();
    Task<List<Reservation>> GetAllDescByHeur();
    Task<bool> DeleteReservationAsync(string idAdherent, string cote, DateTime heureReservation);
}

public class ReservationService(
    IReservationRepository reservationRepository,
    IPretRepository pretRepository,
    INoticesRepository noticesRepository) : IReservationService
{
    private readonly IReservationRepository _reservationRepository = reservationRepository;
    private readonly INoticesRepository _noticesRepository = noticesRepository;
    private readonly IPretRepository _pretRepository = pretRepository;

    // Sample method to demonstrate repository usage
    public async Task<Reservation?> CreateReservationAsync(CreateReservationRequestDto reservation)
    {
        ArgumentNullException.ThrowIfNull(reservation);
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
        catch (Exception ex)
        {
            return null;
        }
    }

    public async Task<bool> CheckAdherentReservingCote(string AdherentId, string cote)
    {
        ArgumentNullException.ThrowIfNull(AdherentId);
        ArgumentNullException.ThrowIfNull(cote);
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
        ArgumentNullException.ThrowIfNull(queryParameters);
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
            var search = queryParameters.Search.ToUpperInvariant(); // only once, on the in-memory value
            query = query.Where(x =>
                x.IdAdherent.ToUpperInvariant().Contains(search, StringComparison.InvariantCulture) ||
                x.Nom!.ToUpperInvariant().Contains(search, StringComparison.InvariantCulture) ||
                x.Prenom!.ToUpperInvariant().Contains(search, StringComparison.InvariantCulture) ||
                x.Cote.ToUpperInvariant().Contains(search, StringComparison.InvariantCulture) ||
                x.TitrePropre!.ToUpperInvariant().Contains(search, StringComparison.InvariantCulture));
        }
        if (!string.IsNullOrEmpty(queryParameters.OrderBy))
        {
            query = queryParameters.OrderBy.ToUpperInvariant() switch
            {
                "COTE ASC" => query.OrderBy(x => x.Cote),
                "COTE DESC" => query.OrderByDescending(x => x.Cote),

                "TITREPROPRE ASC" => query.OrderBy(x => x.TitrePropre),
                "TITREPROPRE DESC" => query.OrderByDescending(x => x.TitrePropre),


                "NOM ASC" => query.OrderBy(x => x.Nom),
                "NOM DESC" => query.OrderByDescending(x => x.Nom),

                "PRENOM ASC" => query.OrderBy(x => x.Prenom),
                "PRENOM DESC" => query.OrderByDescending(x => x.Prenom),

                "IDADHERENT ASC" => query.OrderBy(x => x.IdAdherent),
                "IDADHERENT DESC" => query.OrderByDescending(x => x.IdAdherent),


                "HEURERESERVATION ASC" => query.OrderBy(x => x.HeureReservation),
                "HEURERESERVATION DESC" => query.OrderByDescending(x => x.HeureReservation),

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

    public async Task<List<RelanceDto>> GetRelances()
    {
        var allReservations = await _reservationRepository.GetQueryable()
                        .Include(r => r.Adherent)
                            .ThenInclude(a => a.Categorie)
                        .Include(r => r.Adherent)
                            .ThenInclude(a => a.Position)
                        .Include(r => r.Notice)
                        .ToListAsync();

        List<RelanceDto> relancesList = [];
        foreach (string cote in allReservations.Select(r => r.Cote).Distinct())
        {
            int bloquedCount = await _pretRepository.GetQueryable()
                                .CountAsync(p => p.IdAdherent == "99/999" && p.IdExemplaire.StartsWith(cote + "/"));

            var firstInQueue = allReservations.OrderBy(r => r.HeureReservation).Take(bloquedCount).ToList();
            foreach (var res in firstInQueue)
            {
                relancesList.Add(new RelanceDto
                {
                    IdAdherent = res.IdAdherent,
                    Nom = res.Adherent.Nom!,
                    Prenom = res.Adherent.Prenom!,
                    Position = res.Adherent.Position!.LibellePosition!,
                    Categorie = res.Adherent.Categorie!.LibelleCategorie!,
                    Cote = res.Cote,
                    TitrePropre = res.Notice.TitrePropre!,
                    IdNotice = res.Notice.IdNotice
                });
            }
        }

        return relancesList;

    }
    public async Task<bool> DeleteReservationAsync(string idAdherent, string cote, DateTime heureReservation)
    {
        ArgumentNullException.ThrowIfNull(idAdherent);
        ArgumentNullException.ThrowIfNull(cote);
        Console.WriteLine("##### Data :" + heureReservation);
        var reservation = await _reservationRepository.GetQueryable()
            .FirstOrDefaultAsync(
                r => r.IdAdherent == idAdherent &&
                r.Cote == cote &&
                r.HeureReservation.Year == heureReservation.Year &&
                r.HeureReservation.Month == heureReservation.Month &&
                r.HeureReservation.Day == heureReservation.Day &&
                r.HeureReservation.Hour == heureReservation.Hour &&
                r.HeureReservation.Minute == heureReservation.Minute &&
                r.HeureReservation.Second == heureReservation.Second
            );
        if (reservation == null)
        {
            return false;
        }

        try
        {
            await _reservationRepository.DeleteAsync(reservation);
            return true;
        }
        catch (System.Exception)
        {
            return false;
        }
    }
}