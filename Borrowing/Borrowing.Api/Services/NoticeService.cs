using Borrowing.Api.Repositories;
using Microsoft.EntityFrameworkCore;
using Shared.Models;
using Borrowing.SharedClasses.Responses.Notice;
namespace Borrowing.Api.Services;

public interface INoticeService
{
    Task<Notice?> GetNoticeAsync(string cote);
    Task<CheckNoticeDto> GetNoticeWithDetailsByCoteAsync(string cote);

}

public class NoticeService : INoticeService
{
    private readonly INoticesRepository _noticesRepository;
    private readonly IExemplairesRepository _exemplairesRepository;
    private readonly IReservationRepository _reservationRepository;

    private readonly IPretRepository _pretsRepository;

    public NoticeService(
        INoticesRepository noticesRepository,
        IExemplairesRepository exemplairesRepository,
        IReservationRepository reservationRepository,
        IPretRepository pretRepository

    )
    {
        _noticesRepository = noticesRepository;
        _exemplairesRepository = exemplairesRepository;
        _reservationRepository = reservationRepository;
        _pretsRepository = pretRepository;
    }

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

    public async Task<CheckNoticeDto> GetNoticeWithDetailsByCoteAsync(string cote)
    {
        var notice = await _noticesRepository.GetQueryable()
            .Where(n => n.Cote == cote)
            .FirstOrDefaultAsync();

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

        return new CheckNoticeDto
        {
            Notice = notice,
            Reservations = reservations,
            Exemplaires = exemplairesWithPrets
        };
    }

}