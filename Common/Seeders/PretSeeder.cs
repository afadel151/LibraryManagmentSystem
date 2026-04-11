using Microsoft.EntityFrameworkCore;
using Common.Models;

namespace Common.Seeders;

using Common.Data;
public class PretSeeder : ISeeder
{
    public int Order => 3;

    public async Task SeedAsync(LibraryDbContext context)
    {
        ArgumentNullException.ThrowIfNull(context);
        var count = await context.Database
            .SqlQueryRaw<int>("SELECT COUNT(*) AS \"Value\" FROM MATAOUI.PRET")
            .FirstOrDefaultAsync();
        if (count > 0) return;
        var prets = new List<Pret>
        {
            new() { IdAdherent = "B001", IdExemplaire = "EX001", DatePret = new DateTime(2026, 3, 1), EtatDuree = "F" },
            new() { IdAdherent = "B002", IdExemplaire = "EX004", DatePret = new DateTime(2026, 3, 5), EtatDuree = "F" },
            new() { IdAdherent = "B003", IdExemplaire = "EX003", DatePret = new DateTime(2026, 3, 10), EtatDuree = "F" },
            new() { IdAdherent = "B004", IdExemplaire = "EX006", DatePret = new DateTime(2026, 3, 12), EtatDuree = "F" },
            new() { IdAdherent = "C001", IdExemplaire = "EX005", DatePret = new DateTime(2026, 3, 15), EtatDuree = "F" },
            new() { IdAdherent = "B001", IdExemplaire = "EX002", DatePret = new DateTime(2026, 3, 20), EtatDuree = "F" },
            new() { IdAdherent = "B002", IdExemplaire = "EX007", DatePret = new DateTime(2026, 3, 25), EtatDuree = "F" },
            new() { IdAdherent = "B003", IdExemplaire = "EX008", DatePret = new DateTime(2026, 3, 28), EtatDuree = "F" },
            new() { IdAdherent = "B004", IdExemplaire = "EX009", DatePret = new DateTime(2026, 3, 30), EtatDuree = "F" },
            new() { IdAdherent = "C001", IdExemplaire = "EX010", DatePret = new DateTime(2026, 4, 1), EtatDuree = "F" },
            new() { IdAdherent = "B001", IdExemplaire = "EX011", DatePret = new DateTime(2026, 4, 5), EtatDuree = "F" },
            new() { IdAdherent = "B002", IdExemplaire = "EX012", DatePret = new DateTime(2026, 4, 10), EtatDuree = "F" },
            new() { IdAdherent = "B003", IdExemplaire = "EX013", DatePret = new DateTime(2026, 4, 15), EtatDuree = "F" },
            new() { IdAdherent = "B004", IdExemplaire = "EX014", DatePret = new DateTime(2026, 4, 20), EtatDuree = "F" },
            new() { IdAdherent = "C001", IdExemplaire = "EX015", DatePret = new DateTime(2026, 4, 25), EtatDuree = "F" },

        };

        await context.Prets.AddRangeAsync(prets);
        await context.SaveChangesAsync();
    }
}
