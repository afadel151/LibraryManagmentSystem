using Borrowing.Api.Repositories;
using Microsoft.EntityFrameworkCore;
using Shared.Models;
using Borrowing.SharedClasses.Responses.Notice;

using Borrowing.SharedClasses.Common;
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

}

public class NoticeService(
    INoticesRepository noticesRepository,
    IExemplairesRepository exemplairesRepository,
    IReservationRepository reservationRepository,
    IPretRepository pretRepository,
    IHistoriquePretRepository historiquePretRepository

    ) : INoticeService
{
    private readonly INoticesRepository _noticesRepository = noticesRepository;
    private readonly IExemplairesRepository _exemplairesRepository = exemplairesRepository;
    private readonly IReservationRepository _reservationRepository = reservationRepository;

    private readonly IPretRepository _pretsRepository = pretRepository;
    private readonly IHistoriquePretRepository _historiquePretRepository = historiquePretRepository;

    public async Task<Notice?> GetNoticeAsync(string cote)
    {
        return await _noticesRepository.GetQueryable()
            .Where(
                n => n.Cote == cote
            ).FirstOrDefaultAsync();
    }
    public async Task<List<Exemplaire>> GetAvailableCopies(string cote)
    {
        return await _exemplairesRepository.GetQueryable()
                .Where(
                    e => e.Cote == cote && e.IdEtat == 1
                ).ToListAsync();
    }

    public async Task<NoticeWithResExe?> GetNoticeWithDetailsByCoteAsync(string cote)
    {
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
        return await _exemplairesRepository.GetQueryable()
            .Where(e => e.IdExemplaire == idExemplaire)
            .FirstOrDefaultAsync();
    }

    public async Task<PagedResult<NoticeDto>> GetNoticesAsync(PaginatedQueryParameters queryParameters)
    {
        var notices = _noticesRepository.GetQueryable(n => n.TypeNotice).Include(n=> n.Exemplaires).ThenInclude(e => e.Prets)
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
                        ExemplaireDispo = n.Exemplaires.Count(e => e.IdEtat == 1 ),
                        ExemplaireEnPret = n.Exemplaires.Count(e => e.IdEtat == 2 ),
                        Reservations = reservations.Where(e => e.Cote == n.Cote).Count(),
                        CopiesBloques = n.Exemplaires.Count(e => e.Prets.Any(p=> p.IdAdherent == "99/999"))
                    };

        if (!string.IsNullOrEmpty(queryParameters.OrderBy))
        {
            query = queryParameters.OrderBy.ToLower() switch
            {
                "titrepropre asc" => query.OrderBy(x => x.TitrePropre),
                "titrepropre desc" => query.OrderByDescending(x => x.TitrePropre),

                "cote asc" => query.OrderBy(x => x.Cote),
                "cote desc" => query.OrderByDescending(x => x.Cote),

                "typenotice1 asc" => query.OrderBy(x => x.TypeNotice1),
                "typenotice1 desc" => query.OrderByDescending(x => x.TypeNotice1),

                "exemplairedispo asc" => query.OrderBy(x => x.ExemplaireDispo),
                "exemplairedispo desc" => query.OrderByDescending(x => x.ExemplaireDispo),

                "exemplaireenpret asc" => query.OrderBy(x => x.ExemplaireEnPret),
                "exemplaireenpret desc" => query.OrderByDescending(x => x.ExemplaireEnPret),

                "reservations asc" => query.OrderBy(x => x.Reservations),
                "reservations desc" => query.OrderByDescending(x => x.Reservations),

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
        var exemplaires = await _exemplairesRepository.GetQueryable(e => e.Prets,e=>e.HistoriquePrets,e => e.EtatExemplaire!)
                            .Where(ex => ex.Cote == notice!.Cote)
                            .ToListAsync();
        
        var reservations = await _reservationRepository.GetQueryable()
                            .Where(res => res.Cote == notice.Cote)
                            .ToListAsync();
        
        return new NoticeProfileDto
        {
            Notice = notice,
            Exemplaires = exemplaires,
            Reservations= reservations
        };
        
    }

    public async Task<Exemplaire?> GetExemplaireDetailedAsync(string Id)
    {
        var exemplaire = await _exemplairesRepository.GetQueryable(
            e=> e.EtatExemplaire!
            )
            .Where(e => e.IdExemplaire == Id)
            .Include(e => e.Prets).ThenInclude(p => p.Adherent).ThenInclude(a => a.Categorie)
            .Include(e => e.HistoriquePrets).ThenInclude(h => h.Adherent).ThenInclude(a => a.Categorie)
            .FirstOrDefaultAsync();
        if (exemplaire == null)
        {
            return null;
        }
        return exemplaire;
    }
}