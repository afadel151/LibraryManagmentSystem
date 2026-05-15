using Common.Models;
using Inventory.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Inventory.Services;

public record NoticeTypeStat(string TypeNotice, int Total, int NonIndexees, int SansExemplaire);

public record NoticeRow(
    decimal IdNotice,
    string Cote,
    string TitrePropre,
    string TypeNotice,
    string Accessibilite,
    decimal IsIndexed);

public record DashboardStats(
    int TotalNotices,
    int TotalExemplaires,
    int TotalAdherents,
    int AdherentsActifs,
    int NoticesNonIndexees,
    int ExemplairesNonCrees,
    IReadOnlyList<NoticeTypeStat> NoticesByType,
    IReadOnlyList<NoticeRow> RecentNotices);

public interface IDashboardService
{
    Task<DashboardStats> GetStatsAsync();
}

public class DashboardService(
    INoticeRepository noticeRepo,
    IExemplaireRepository exemplaireRepo,
    IAdherentRepository adherentRepo,
    IBaseRepository<TypeNotice> typeNoticeRepo) : IDashboardService
{
    public async Task<DashboardStats> GetStatsAsync()
    {
        var totalNotices = await noticeRepo.CountAsync();
        var totalExemplaires = await exemplaireRepo.GetQueryable().CountAsync();
        var totalAdherents = await adherentRepo.GetQueryable().CountAsync();
        var adherentsActifs = await adherentRepo.GetQueryable().CountAsync(a => a.EtatAdherent == 1);
        var noticesNonIndexees = await noticeRepo.CountNonIndexeesAsync();
        var exemplaireNonCrees = await noticeRepo.CountSansExemplaireAsync();

        var typeNotices = await typeNoticeRepo.GetQueryable()
            .OrderBy(t => t.IdType)
            .ToListAsync();

        var statsByType = await noticeRepo.GetStatsByTypeAsync();
        var statsByTypeDict = statsByType.ToDictionary(s => s.IdType);

        var noticesByType = typeNotices.Select(t =>
        {
            statsByTypeDict.TryGetValue(t.IdType, out var s);
            return new NoticeTypeStat(
                t.TypeNotice1 ?? "—",
                s.Total,
                s.NonIndexees,
                s.SansExemplaire);
        }).ToList();

        var recentRaw = await noticeRepo.GetQueryable()
            .Include(n => n.TypeNotice)
            .OrderByDescending(n => n.IdNotice)
            .Take(10)
            .ToListAsync();

        var recentNotices = recentRaw.Select(n => new NoticeRow(
            n.IdNotice,
            n.Cote ?? "—",
            n.TitrePropre ?? "—",
            n.TypeNotice?.TypeNotice1 ?? "—",
            n.Accessibilite ?? "1",
            n.IsIndexed ?? 0)).ToList();

        return new DashboardStats(
            totalNotices,
            totalExemplaires,
            totalAdherents,
            adherentsActifs,
            noticesNonIndexees,
            exemplaireNonCrees,
            noticesByType,
            recentNotices);
    }
}