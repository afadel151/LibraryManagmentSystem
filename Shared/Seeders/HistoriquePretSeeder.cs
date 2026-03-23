using Microsoft.EntityFrameworkCore;
using Shared.Data;
using Shared.Models;

namespace Shared.Seeders;

public class HistoriquePretSeeder : ISeeder
{
    public int Order => 3;

    public async Task SeedAsync(LibraryDbContext context)
    {
        if (await context.HistoriquePrets.AnyAsync()) return;

        var historiques = new List<HistoriquePret>
        {
            new() { IdAdherent = "ADH001", IdExemplaire = "EX002", DatePret = new DateTime(2026, 1, 10), DateRetour = new DateTime(2026, 1, 22) },
            new() { IdAdherent = "ADH002", IdExemplaire = "EX005", DatePret = new DateTime(2026, 1, 15), DateRetour = new DateTime(2026, 1, 28) },
            new() { IdAdherent = "ADH003", IdExemplaire = "EX008", DatePret = new DateTime(2026, 2, 1), DateRetour = new DateTime(2026, 2, 18) },
            new() { IdAdherent = "ADH006", IdExemplaire = "EX006", DatePret = new DateTime(2026, 2, 5), DateRetour = new DateTime(2026, 2, 25) },
        };

        await context.HistoriquePrets.AddRangeAsync(historiques);
        await context.SaveChangesAsync();
    }
}
