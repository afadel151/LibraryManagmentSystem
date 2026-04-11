using Borrowing.Api.Repositories;
using Microsoft.EntityFrameworkCore;
using Common.Models;
using Borrowing.SharedClasses.Responses.Notice;

using Borrowing.SharedClasses.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
namespace Borrowing.Api.Services;

public interface INoticeService
{
    Task<Notice?> GetNoticeAsync(string cote);
    Task<NoticeWithResExe?> GetNoticeWithDetailsByCoteAsync(string cote);
    Task<Exemplaire?> GetExemplaireAsync(string idExemplaire);
    Task<Exemplaire?> GetExemplaireDetailedAsync(string Id);
    Task<PagedResult<NoticeDto>> GetNoticesAsync(PaginatedQueryParameters queryParameters);
    Task<List<TopLoanedNoticeDto>> GetTopLoanedNoticesAsync(int n);
    Task<NoticeProfileDto?> GetNoticeProfile(int NoticeId);
    Task<PagedResult<ExemplaireBloqueDto>> GetExemplaireBloquesAsync(PaginatedQueryParameters parameters);
    Task<CheckNoticeResponseDto> CheckNoticeAsync(string cote, string adherentId);

    Task<bool> UpdateExemplaire(Exemplaire e, int etat);

}

public class NoticeService(
    INoticesRepository noticesRepository,
    IExemplairesRepository exemplairesRepository,
    IReservationRepository reservationRepository,
    IPretRepository pretRepository,
    IHistoriquePretRepository historiquePretRepository,
    ILogger<NoticeService> logger
    ) : INoticeService
{
    private readonly INoticesRepository _noticesRepository = noticesRepository;
    private readonly IExemplairesRepository _exemplairesRepository = exemplairesRepository;
    private readonly IReservationRepository _reservationRepository = reservationRepository;

    private readonly IPretRepository _pretsRepository = pretRepository;
    private readonly IHistoriquePretRepository _historiquePretRepository = historiquePretRepository;

    private readonly ILogger<NoticeService> _logger = logger;
    public async Task<bool> UpdateExemplaire(Exemplaire e, int etat)
    {
        ArgumentNullException.ThrowIfNull(e);
        e.IdEtat = (decimal)etat;
        try
        {
            await _exemplairesRepository.UpdateAsync(e);
            return true;
        }
        catch (System.Exception)
        {
            return false;
        }
    }
    public async Task<Notice?> GetNoticeAsync(string cote)
    {
        ArgumentNullException.ThrowIfNull(cote);
        return await _noticesRepository.GetQueryable()
            .Where(
                n => n.Cote == cote
            ).FirstOrDefaultAsync();
    }
    public async Task<List<Exemplaire>> GetAvailableCopies(string cote)
    {
        ArgumentNullException.ThrowIfNull(cote);
        return await _exemplairesRepository.GetQueryable()
                .Where(
                    e => e.Cote == cote && e.IdEtat == 1
                ).ToListAsync();
    }

    public async Task<NoticeWithResExe?> GetNoticeWithDetailsByCoteAsync(string cote)
    {
        ArgumentNullException.ThrowIfNull(cote);
        var notice = await _noticesRepository.GetQueryable()
            .Where(n => n.Cote == cote)
            .SingleOrDefaultAsync();

        var reservations = await _reservationRepository.GetQueryable()
            .Where(r => r.Cote == cote)
            .ToListAsync();

        var exemplaires = await _exemplairesRepository.GetQueryable()
            .Where(e => e.Cote == cote)
            .ToListAsync();

        var exemplairIds = exemplaires.Select(e => e.IdExemplaire).ToList();

        var prets = await _pretsRepository.GetQueryable()
            .Where(p => exemplairIds.Contains(p.IdExemplaire))
            .ToListAsync();

        var exemplairesWithPrets = exemplaires.Select(e => new Exemplaire
        {
            IdExemplaire = e.IdExemplaire,
            IdEtat = e.IdEtat,
            Cote = e.Cote,
            Prets = prets.Where(p => p.IdExemplaire == e.IdExemplaire).ToList()
        }).ToList();

        if (notice != null)
        {
            return new NoticeWithResExe
            {
                Notice = notice,
                Reservations = reservations,
                Exemplaires = exemplairesWithPrets
            };
        }
        else
        {
            return null;
        }
    }

    public async Task<Exemplaire?> GetExemplaireAsync(string idExemplaire)
    {
        ArgumentNullException.ThrowIfNull(idExemplaire);
        return await _exemplairesRepository.GetQueryable()
            .Where(e => e.IdExemplaire == idExemplaire)
            .FirstOrDefaultAsync();
    }

    public async Task<PagedResult<NoticeDto>> GetNoticesAsync(PaginatedQueryParameters queryParameters)
    {
        ArgumentNullException.ThrowIfNull(queryParameters);
        var notices = _noticesRepository.GetQueryable(n => n.TypeNotice).Include(n => n.Exemplaires).ThenInclude(e => e.Prets)
                    .Where(p =>
                            string.IsNullOrEmpty(queryParameters.Search) ||
                            EF.Functions.Like(p.Cote!.ToUpper(), queryParameters.Search.ToUpper() + "%") ||
                            EF.Functions.Like(p.TitrePropre!.ToUpper(), queryParameters.Search.ToUpper() + "%")
                    );

        var exemplaires = _exemplairesRepository.GetQueryable();

        var reservations = _reservationRepository.GetQueryable();
        var query = from n in notices
                    select new NoticeDto
                    {
                        IdNotice = n.IdNotice,
                        TitrePropre = n.TitrePropre ?? string.Empty,
                        Cote = n.Cote,
                        TypeNotice1 = n.TypeNotice.TypeNotice1 ?? string.Empty,
                        ExemplaireDispo = n.Exemplaires.Count(e => e.IdEtat == 1),
                        ExemplaireEnPret = n.Exemplaires.Count(e => e.IdEtat == 2),
                        Reservations = reservations.Where(e => e.Cote == n.Cote).Count(),
                        CopiesBloques = n.Exemplaires.Count(e => e.Prets.Any(p => p.IdAdherent == "99/999"))
                    };

        if (!string.IsNullOrEmpty(queryParameters.OrderBy))
        {
            query = queryParameters.OrderBy.ToUpper() switch
            {
                "TITREPROPRE ASC" => query.OrderBy(x => x.TitrePropre),
                "TITREPROPRE DESC" => query.OrderByDescending(x => x.TitrePropre),

                "COTE ASC" => query.OrderBy(x => x.Cote),
                "COTE DESC" => query.OrderByDescending(x => x.Cote),

                "TYPENOTICE1 ASC" => query.OrderBy(x => x.TypeNotice1),
                "TYPENOTICE1 DESC" => query.OrderByDescending(x => x.TypeNotice1),

                "EXEMPLAIREDISPO ASC" => query.OrderBy(x => x.ExemplaireDispo),
                "EXEMPLAIREDISPO DESC" => query.OrderByDescending(x => x.ExemplaireDispo),

                "EXEMPLAIREENPRET ASC" => query.OrderBy(x => x.ExemplaireEnPret),
                "EXEMPLAIREENPRET DESC" => query.OrderByDescending(x => x.ExemplaireEnPret),

                "RESERVATIONS ASC" => query.OrderBy(x => x.Reservations),
                "RESERVATIONS DESC" => query.OrderByDescending(x => x.Reservations),

                _ => query.OrderBy(x => x.Cote)
            };
        }
        else
        {
            query = query.OrderBy(x => x.Cote); // Default orderin
        }

        var totalCount = await query.CountAsync();
        var data = await query
            .Skip((queryParameters.PageNumber - 1) * queryParameters.PageSize)
            .Take(queryParameters.PageSize)
            .ToListAsync();
        return new PagedResult<NoticeDto>
        {
            Data = data,
            TotalCount = totalCount,
            PageNumber = queryParameters.PageNumber,
            PageSize = queryParameters.PageSize
        };
    }
    public async Task<List<TopLoanedNoticeDto>> GetTopLoanedNoticesAsync(int n)
    {
        var activePretIds = _pretsRepository.GetQueryable()
            .Select(p => p.IdExemplaire);
        var historiquePretIds = _historiquePretRepository.GetQueryable()
            .Select(hp => hp.IdExemplaire);
        var allPretExemplaireIds = activePretIds.Concat(historiquePretIds); // UNION 
        var result = await _noticesRepository.GetQueryable()
            .Where(n => n.Cote != null)
            .Join(_exemplairesRepository.GetQueryable().Where(e => e.Cote != null),
                n => n.Cote,
                e => e.Cote,
                (n, e) => new { n.IdNotice, n.TitrePropre, n.Cote, e.IdExemplaire }
            )
            .Join(allPretExemplaireIds,
                ne => ne.IdExemplaire,
                id => id,
                (ne, id) => new { ne.IdNotice, ne.TitrePropre, ne.Cote }
            )
            .GroupBy(x => new { x.IdNotice, x.TitrePropre, x.Cote })
            .Select(g => new TopLoanedNoticeDto
            {
                TitrePropre = g.Key.TitrePropre ?? "—",
                Cote = g.Key.Cote ?? string.Empty,
                TotalPrets = g.Count()
            })
            .OrderByDescending(x => x.TotalPrets)
            .Take(n)
            .ToListAsync();
        return result;
    }

    public async Task<NoticeProfileDto?> GetNoticeProfile(int NoticeId)
    {
        var notice = await _noticesRepository.GetQueryable(
            n => n.Auteurs,
            n => n.Langues,
            n => n.Pays,
            n => n.Periodicite!,
            n => n.TypeNotice,
            n => n.Selections
        )
        .Where(n => n.IdNotice == (decimal)NoticeId)
        .FirstOrDefaultAsync();

        if (notice == null)
        {
            return null;
        }
        var exemplaires = await _exemplairesRepository.GetQueryable(e => e.Prets, e => e.HistoriquePrets, e => e.EtatExemplaire!)
                            .Where(ex => ex.Cote == notice!.Cote)
                            .ToListAsync();

        var reservations = await _reservationRepository.GetQueryable()
                            .Where(res => res.Cote == notice.Cote)
                            .ToListAsync();

        return new NoticeProfileDto
        {
            Notice = notice,
            Exemplaires = exemplaires,
            Reservations = reservations
        };

    }

    public async Task<Exemplaire?> GetExemplaireDetailedAsync(string Id)
    {
        ArgumentNullException.ThrowIfNull(Id);
        var exemplaire = await _exemplairesRepository.GetQueryable(
            e => e.EtatExemplaire!
            )
            .Where(e => e.IdExemplaire == Id)
                .Include(e => e.Prets)
                    .ThenInclude(p => p.Adherent)
                        .ThenInclude(a => a.Categorie)
                .Include(e => e.HistoriquePrets)
                    .ThenInclude(h => h.Adherent)
                        .ThenInclude(a => a.Categorie)
            .FirstOrDefaultAsync();
        if (exemplaire == null)
        {
            return null;
        }
        return exemplaire;
    }
    public async Task<CheckNoticeResponseDto> CheckNoticeAsync(string cote, string adherentId)
    {
        ArgumentNullException.ThrowIfNull(cote);
        ArgumentNullException.ThrowIfNull(adherentId);
        var pret = await _pretsRepository.GetQueryable()
                        .Where(p =>
                            EF.Functions.Like(p.IdExemplaire.ToUpper(), cote.ToUpper() + "/%")
                        ).FirstOrDefaultAsync();
        var notice = await _noticesRepository.GetQueryable(n => n.Reservations, n => n.Exemplaires).FirstOrDefaultAsync(n => n.Cote == cote); ;
        if (notice == null)
            return new CheckNoticeResponseDto { Status = CheckNoticeEnum.NOT_FOUND };
            
        if (pret != null)
        {
            return new CheckNoticeResponseDto
            {
                Status = CheckNoticeEnum.ALREADY_BORROWED,
                Titre = notice.TitrePropre
            };
        }


        _logger.LogInformation("Notice titre : " + notice.TitrePropre!);
        var titre = notice.TitrePropre!;

        List<string> availableCopies = [.. notice.Exemplaires.Where(e => e.IdEtat == 1).Select(e => e.IdExemplaire)];

        List<Pret> blockedCopies = await _pretsRepository.GetQueryable()
            .Where(p => EF.Functions.Like(
                p.IdExemplaire.ToUpper(),
                cote.ToUpper() + "/%"))
            .Where(p => p.IdAdherent == "99/999")
            .OrderBy(p => p.DatePret)
            .ToListAsync();

        if (notice.Reservations.Any(r => r.IdAdherent == adherentId))
        {
            var orderedReservations = await _reservationRepository.GetQueryable()
                        .OrderByDescending(p => p.HeureReservation)
                        .Take(blockedCopies.Count)
                        .ToListAsync();

            if (orderedReservations.Any(r => r.IdAdherent == adherentId))
            {
                int queuePosition = orderedReservations.FindIndex(r => r.IdAdherent == adherentId);
                return new CheckNoticeResponseDto
                {
                    Status = CheckNoticeEnum.CAN_BORROW_RESERVATEUR,
                    Exemplaires = [blockedCopies.ElementAt(queuePosition).IdExemplaire],
                    Titre = titre
                };
            }
            else
            {
                return new CheckNoticeResponseDto
                {
                    Status = CheckNoticeEnum.RESERVED_NOT_READY,
                    Titre = titre
                };
            }
        }
        else
        {
            if (availableCopies.Count > 0)
            {
                return new CheckNoticeResponseDto
                {
                    Status = CheckNoticeEnum.CAN_BORROW,
                    Exemplaires = availableCopies,
                    Titre = titre
                };
            }
            else
            {
                return new CheckNoticeResponseDto
                {
                    Status = CheckNoticeEnum.CAN_RESERVE,
                    Titre = titre
                };
            }
        }
    }
    public async Task<PagedResult<ExemplaireBloqueDto>> GetExemplaireBloquesAsync(PaginatedQueryParameters parameters)
    {
        ArgumentNullException.ThrowIfNull(parameters);
        var prets = _pretsRepository.GetQueryable()
            .Include(p => p.Exemplaire)
                .ThenInclude(e => e.Notice)
            .Where(p => p.IdAdherent == "99/999");

        var query = from p in prets
                    select new ExemplaireBloqueDto
                    {
                        IdExemplaire = p.IdExemplaire,
                        TitrePropre = p.Exemplaire.Notice.TitrePropre!,
                        IdNotice = p.Exemplaire.Notice.IdNotice,
                        DatePret = p.DatePret
                    };
        var totalCount = await query.CountAsync();
        var data = await query
            .Skip((parameters.PageNumber - 1) * parameters.PageSize)
            .Take(parameters.PageSize)
            .ToListAsync();
        Console.WriteLine("#### prets count: " + totalCount);

        return new PagedResult<ExemplaireBloqueDto>
        {
            Data = data,
            TotalCount = totalCount,
            PageNumber = parameters.PageNumber,
            PageSize = parameters.PageSize
        };

    }
}