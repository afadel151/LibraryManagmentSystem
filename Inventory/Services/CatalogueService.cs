
using Inventory.Models.Catalogue;
using Inventory.Repositories;
namespace Inventory.Services;

using Microsoft.EntityFrameworkCore;
public interface ICatalogueService
{
    Task<NoticeDataTableResult> GetPagedAsync(NoticeDataTableRequest request);
}


public sealed class CatalogueService(
    INoticeRepository noticeRepository
) : ICatalogueService
{
    public async Task<NoticeDataTableResult> GetPagedAsync(NoticeDataTableRequest req)
    {
        var query = noticeRepository
            .GetQueryable(n => n.TypeNotice)
            .AsNoTracking();

        int total = await query.CountAsync();

        if (!string.IsNullOrWhiteSpace(req.Search))
        {
            var s = req.Search.ToLower();
            query = query.Where(n =>
                (n.TitrePropre != null && n.TitrePropre.ToLower().Contains(s)) ||
                (n.Cote != null && n.Cote.ToLower().Contains(s)) ||
                (n.Isbn != null && n.Isbn.ToLower().Contains(s)));
        }

        if (!string.IsNullOrWhiteSpace(req.FilterTitre))
            query = query.Where(n => n.TitrePropre != null &&
                n.TitrePropre.ToLower().Contains(req.FilterTitre.ToLower()));
        if (!string.IsNullOrWhiteSpace(req.FilterCote))
            query = query.Where(n => n.Cote != null &&
                n.Cote.ToLower().Contains(req.FilterCote.ToLower()));

        if (!string.IsNullOrWhiteSpace(req.FilterIsbn))
            query = query.Where(n => n.Isbn != null &&
                n.Isbn.ToLower().Contains(req.FilterIsbn.ToLower()));

        if (!string.IsNullOrWhiteSpace(req.FilterType))
            query = query.Where(n => n.TypeNotice.TypeNotice1 == req.FilterType);

        if (req.FilterUnindexed == "true")
            query = query.Where(n => n.IsIndexed == null || n.IsIndexed == 0);

        int filtered = await query.CountAsync();

        query = (req.OrderColumn, req.OrderDir) switch
        {
            ("titre", "desc") => query.OrderByDescending(n => n.TitrePropre),
            ("titre", _) => query.OrderBy(n => n.TitrePropre),
            ("type", "desc") => query.OrderByDescending(n => n.TypeNotice.TypeNotice1),
            ("type", _) => query.OrderBy(n => n.TypeNotice.TypeNotice1),
            ("cote", "desc") => query.OrderByDescending(n => n.Cote),
            _ => query.OrderBy(n => n.Cote),
        };

        var rows = await query
            .Skip(req.Start)
            .Take(req.Length)
            .Select(n => new NoticeRowDto
            {
                IdNotice = n.IdNotice,
                Cote = n.Cote ?? "—",
                TitrePropre = n.TitrePropre ?? "—",
                TypeNotice = n.TypeNotice.TypeNotice1 ?? "—",
                Accessibilite = n.Accessibilite ?? "0",
                IsIndexed = n.IsIndexed > 0 ? 1 : 0,
                HasExemplaires = n.ExemplaireExiste != null && n.ExemplaireExiste >  0 ? 1 : 0,
            })
            .ToListAsync();

        return new NoticeDataTableResult
        {
            Draw = req.Draw,
            RecordsTotal = total,
            RecordsFiltered = filtered,
            Data = rows,
        };
    }
}