using Borrowing.Api.Repositories;
using Shared.Models;
using Microsoft.EntityFrameworkCore;
using Borrowing.SharedClasses.Common;
using Borrowing.SharedClasses.Responses.Adherent;
namespace Borrowing.Api.Services;

public interface IAdherentService
{
    Task<PagedResult<AdherentDto>> GetAdherentsAsync(PaginatedQueryParameters queryParameters);
    Task<AdherentProfileDto?> GetAdherentWithDetailsAsync(string adherentId);
    Task<DateTime> CalculateExpectedReturnDate(DateTime startDate, decimal duration);
    Task<AdherentsStatsDto> GetStats();
}

public class AdherentService(
    IAdherentRepository adherentRepository,
    IReservationRepository reservationRepository,
    IPenaliteAdherentRepository penaliteAdherentRepository,
    ICategorieRepository categorieRepository,
    IJoursFeriesRepository joursFeriesRepository,
    IPretRepository pretRepository
) : IAdherentService
{
    private readonly IAdherentRepository _adherentRepository = adherentRepository;
    private readonly ICategorieRepository _categorieRepository = categorieRepository;
    private readonly IPenaliteAdherentRepository _penaliteRepository = penaliteAdherentRepository;
    private readonly IReservationRepository _reservationRepository = reservationRepository;
    private readonly IJoursFeriesRepository _joursFeriesRepository = joursFeriesRepository;
    private readonly IPretRepository _pretRepository = pretRepository;




    public async Task<PagedResult<AdherentDto>> GetAdherentsAsync(PaginatedQueryParameters queryParameters)
    {
        var adherents = _adherentRepository.GetQueryable(a => a.Categorie!, a => a.Position!, a => a.PenaliteAdherents, a => a.Reservations, a => a.Prets)
            .Where(p =>
                    string.IsNullOrEmpty(queryParameters.Search) ||
                    EF.Functions.Like(p.IdAdherent.ToUpper(), queryParameters.Search.ToUpper() + "%") ||
                    EF.Functions.Like(p.Nom!.ToUpper(), queryParameters.Search.ToUpper() + "%") ||
                    EF.Functions.Like(p.Prenom!.ToUpper(), queryParameters.Search.ToUpper() + "%")
            );
        var query = from a in adherents
                    select new AdherentDto
                    {
                        IdAdherent = a.IdAdherent,
                        Nom = a.Nom ?? string.Empty,
                        Prenom = a.Prenom ?? string.Empty,
                        Position = a.Position!.LibellePosition ?? string.Empty,
                        Categorie = a.Categorie!.LibelleCategorie ?? string.Empty,
                        Etat = (int)a.EtatAdherent!,
                        Prets = a.Prets.Count,
                        Reservations = a.Reservations.Count,
                        Penalise = a.PenaliteAdherents.Count > 0 ? 1 : 0
                    };
        var totalCount = await query.CountAsync();
        if (!string.IsNullOrWhiteSpace(queryParameters.OrderBy))
        {
            query = queryParameters.OrderBy.ToLower() switch
            {
                "idadherent asc" => query.OrderBy(x => x.IdAdherent),
                "idadherent desc" => query.OrderByDescending(x => x.IdAdherent),


                "nom asc" => query.OrderBy(x => x.Nom),
                "nom desc" => query.OrderByDescending(x => x.Nom),

                "prenom asc" => query.OrderBy(x => x.Prenom),
                "prenom desc" => query.OrderByDescending(x => x.Prenom),

                "categorie asc" => query.OrderBy(x => x.Categorie),
                "categorie desc" => query.OrderByDescending(x => x.Categorie),

                "position asc" => query.OrderBy(x => x.Position!),
                "position desc" => query.OrderByDescending(x => x.Position!),

                "etat asc" => query.OrderBy(x => x.Etat),
                "etat desc" => query.OrderByDescending(x => x.Etat),

                "prets asc" => query.OrderBy(x => x.Prets),
                "prets desc" => query.OrderByDescending(x => x.Prets),

                "reservations asc" => query.OrderBy(x => x.Reservations),
                "reservations desc" => query.OrderByDescending(x => x.Reservations),

                "penalise asc" => query.OrderBy(x => x.Penalise),
                "penalise desc" => query.OrderByDescending(x => x.Penalise),
                _ => query.OrderBy(x => x.IdAdherent)
            };
        }
        else
        {
            query = query.OrderBy(x => x.IdAdherent); // default
        }

        var data = await query
            .Skip((queryParameters.PageNumber - 1) * queryParameters.PageSize)
            .Take(queryParameters.PageSize)
            .ToListAsync();

        return new PagedResult<AdherentDto>
        {
            Data = data,
            TotalCount = totalCount,
            PageNumber = queryParameters.PageNumber,
            PageSize = queryParameters.PageSize
        };

    }
    public async Task<AdherentProfileDto?> GetAdherentWithDetailsAsync(string adherentId)
    {
        var adherent = await _adherentRepository.GetQueryable(a => a.Categorie!, a => a.Position!, a => a.PenaliteAdherents, a => a.Reservations, a => a.Prets).FirstOrDefaultAsync(a => a.IdAdherent == adherentId);

        if (adherent != null)
        {
            return new AdherentProfileDto
            {
                Adherent = adherent,
                Picture = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcQBy606CYdQuQNTxOH0mHl6Lxdker4OH8Nvvg&s"
            };
        }
        return null;
    }


    public async Task<DateTime> CalculateExpectedReturnDate(DateTime startDate, decimal duration)
    {
        DateTime rawReturnDate = startDate.AddDays((double)duration);
        return await Traiter_date(rawReturnDate);
    }

    private async Task<DateTime> Traiter_date(DateTime date)
    {
        bool changement = false;
        // si vendredi ou samedi
        DayOfWeek day = date.DayOfWeek;
        if (day == DayOfWeek.Friday || day == DayOfWeek.Saturday)
        {
            date = date.AddDays(1);
            changement = true;
        }
        else // sinon verif si c'est un jours feriees
        {
            IEnumerable<JoursFery> joursFeries = await _joursFeriesRepository.GetAllAsync();
            bool isHoliday = joursFeries.Any(j => j.DateJourFerie.Date == date.Date);
            if (isHoliday)
            {
                date = date.AddDays(1);
                changement = true;
            }
        }
        // recursivite sur nouvelle date s'il ya un changement
        if (changement)
        {
            return await Traiter_date(date);
        }
        // pas de changement
        return date;
    }

    public async Task<AdherentsStatsDto> GetStats()
    {
        int penalises = await _penaliteRepository.GetQueryable()
                        .GroupBy(p => p.IdAdherent)
                        .CountAsync();

        int totalActifs = await _adherentRepository.GetQueryable()
                        .Where(a => a.EtatAdherent == 0)
                            .CountAsync();

        int pretants = await _pretRepository.GetQueryable()
                        .GroupBy(p => p.IdAdherent)
                        .CountAsync();

        return new AdherentsStatsDto
        {
            TotalActif = totalActifs,
            Penalises = penalises,
            Pretants = pretants
        };

    }
}