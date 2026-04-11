using Microsoft.EntityFrameworkCore;
using Common.Models;

namespace Common.Seeders;
using Common.Data;
public class NoticeSeeder : ISeeder
{
    public int Order => 2;

    public async Task SeedAsync(LibraryDbContext context)
    {
        var count = await context.Database
            .SqlQueryRaw<int>("SELECT COUNT(*) AS \"Value\" FROM MATAOUI.NOTICE")
            .FirstOrDefaultAsync();
        if (count > 0) return;

        var notices = new List<Notice>
        {
            new() { IdNotice = 1, IdType = 1, TitrePropre = "Introduction à l'algorithmique", Cote = "INF-001", Isbn = "978-2-10-005631-5", Date1erPub = "2009", ExemplaireExiste = 1 },
            new() { IdNotice = 2, IdType = 1, TitrePropre = "Algèbre linéaire", Cote = "MAT-001", Isbn = "978-2-10-007451-7", Date1erPub = "2012", ExemplaireExiste = 1 },
            new() { IdNotice = 3, IdType = 1, TitrePropre = "Physique quantique", Cote = "PHY-001", Isbn = "978-2-10-006320-7", Date1erPub = "2015", ExemplaireExiste = 1 },
            new() { IdNotice = 4, IdType = 1, TitrePropre = "Les Misérables", Cote = "LIT-001", Isbn = "978-2-07-040850-4", Date1erPub = "1862", ExemplaireExiste = 1 },
            new() { IdNotice = 5, IdType = 1, TitrePropre = "Histoire de l'Algérie", Cote = "HIS-001", Isbn = "978-9961-0-0815-3", Date1erPub = "2005", ExemplaireExiste = 1 },
            new() { IdNotice = 6, IdType = 1, TitrePropre = "Chimie organique", Cote = "CHM-001", Isbn = "978-2-10-051623-5", Date1erPub = "2018", ExemplaireExiste = 1 },
            new() { IdNotice = 7, IdType = 1, TitrePropre = "Droit constitutionnel", Cote = "DRT-001", Isbn = "978-2-247-17096-8", Date1erPub = "2020", ExemplaireExiste = 1 },
            new() { IdNotice = 8, IdType = 2, TitrePropre = "Apprentissage automatique appliqué", Cote = "INF-002", Date1erPub = "2023", ExemplaireExiste = 0 },
        };

        await context.Notices.AddRangeAsync(notices);
        await context.SaveChangesAsync();
    }
}
