using Common.Data;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace Inventory.Views.Home;

public class NoticeTypeStat
{
    public string TypeNotice { get; set; } = "";
    public int Total { get; set; }
    public int NonIndexees { get; set; }
    public int SansExemplaire { get; set; }
}

public class NoticeRow
{
    public decimal IdNotice { get; set; }
    public string Cote { get; set; } = "";
    public string TitrePropre { get; set; } = "";
    public string TypeNotice { get; set; } = "";
    public string Accessibilite { get; set; } = "1";
    public int IsIndexed { get; set; }
}

public class IndexModel : PageModel
{
    private readonly LibraryDbContext _db;

    public IndexModel(LibraryDbContext db) => _db = db;

    public int TotalNotices { get; private set; }
    public int NoticesThisMonth { get; private set; }
    public int TotalExemplaires { get; private set; }
    public int ExemplairesNonCrees { get; private set; }
    public int TotalAdherents { get; private set; }
    public int AdherentsActifs { get; private set; }
    public int NoticesNonIndexees { get; private set; }
    public List<NoticeTypeStat> NoticesByType { get; private set; } = new();
    public List<NoticeRow> RecentNotices { get; private set; } = new();

    public async Task OnGetAsync()
    {
        TotalNotices = await _db.Notices.CountAsync();

        ExemplairesNonCrees = await _db.Notices
            .Where(n => n.ExemplaireExiste == 0 && n.Accessibilite == "1")
            .CountAsync();

        TotalExemplaires = await _db.Exemplaires.CountAsync();

        TotalAdherents = await _db.Adherents.CountAsync();

        AdherentsActifs = await _db.Adherents
            .Where(a => a.EtatAdherent == 1)
            .CountAsync();

        NoticesNonIndexees = await _db.Notices
            .Where(n => n.IsIndexed == 0)
            .CountAsync();

        NoticesByType = await _db.TypeNotices
            .OrderBy(t => t.IdType)
            .Select(t => new NoticeTypeStat
            {
                TypeNotice = t.TypeNotice1!,
                Total = _db.Notices.Count(n => n.IdType == t.IdType),
                NonIndexees = _db.Notices.Count(n => n.IdType == t.IdType && n.IsIndexed == 0),
                SansExemplaire = _db.Notices.Count(n => n.IdType == t.IdType && n.ExemplaireExiste == 0 && n.Accessibilite == "1"),
            })
            .ToListAsync();

        RecentNotices = await _db.Notices
            .Join(_db.TypeNotices, n => n.IdType, t => t.IdType,
                (n, t) => new NoticeRow
                {
                    IdNotice = n.IdNotice,
                    Cote = n.Cote ?? "",
                    TitrePropre = n.TitrePropre ?? "",
                    TypeNotice = t.TypeNotice1!,
                    Accessibilite = n.Accessibilite ?? "1",
                    IsIndexed = (int)(n.IsIndexed ?? 0),
                })
            .OrderByDescending(n => n.IdNotice)
            .Take(10)
            .ToListAsync();
    }
}