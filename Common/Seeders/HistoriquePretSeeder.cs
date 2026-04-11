using Microsoft.EntityFrameworkCore;
using Common.Models;

namespace Common.Seeders;
using Common.Data;
public class HistoriquePretSeeder : ISeeder
{
    public int Order => 3;

    public async Task SeedAsync(LibraryDbContext context)
    {
        var count = await context.Database
            .SqlQueryRaw<int>("SELECT COUNT(*) AS \"Value\" FROM MATAOUI.HISTORIQUE_PRET")
            .FirstOrDefaultAsync();
        if (count > 0) return;

        var historiques = new List<(string IdAdherent, string IdExemplaire, DateTime DatePret, DateTime DateRetour)>
        {
            ("B001", "EX002", new DateTime(2026, 1, 10), new DateTime(2026, 1, 22)),
            ("B002", "EX005", new DateTime(2026, 1, 15), new DateTime(2026, 1, 28)),
            ("B003", "EX008", new DateTime(2026, 2, 1),  new DateTime(2026, 2, 18)),
            ("B004", "EX006", new DateTime(2026, 2, 5),  new DateTime(2026, 2, 25)),
        };

        foreach (var (IdAdherent, IdExemplaire, DatePret, DateRetour) in historiques)
        {
            await context.Database.ExecuteSqlRawAsync(
                "INSERT INTO MATAOUI.HISTORIQUE_PRET (ID_ADHERENT, ID_EXEMPLAIRE, DATE_PRET, DATE_RETOUR) VALUES (:p0, :p1, :p2, :p3)",
                IdAdherent, IdExemplaire, DatePret, DateRetour);
        }
    }
}
