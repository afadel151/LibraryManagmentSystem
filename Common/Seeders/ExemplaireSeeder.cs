using Microsoft.EntityFrameworkCore;
using Common.Models;
using Common.Data;
namespace Common.Seeders;

public class ExemplaireSeeder : ISeeder
{
    public int Order => 2;

    public async Task SeedAsync(LibraryDbContext context)
    {
        ArgumentNullException.ThrowIfNull(context);
        var count = await context.Database
            .SqlQueryRaw<int>("SELECT COUNT(*) AS \"Value\" FROM MATAOUI.EXEMPLAIRE")
            .FirstOrDefaultAsync();
        if (count > 0) return;

        var exemplaires = new List<Exemplaire>
        {
            new() { IdExemplaire = "EX001", IdEtat = 1, Cote = "INF-001" },
            new() { IdExemplaire = "EX002", IdEtat = 1, Cote = "INF-001" },
            new() { IdExemplaire = "EX003", IdEtat = 1, Cote = "MAT-001" },
            new() { IdExemplaire = "EX004", IdEtat = 2, Cote = "MAT-001" },
            new() { IdExemplaire = "EX005", IdEtat = 1, Cote = "PHY-001" },
            new() { IdExemplaire = "EX006", IdEtat = 1, Cote = "LIT-001" },
            new() { IdExemplaire = "EX007", IdEtat = 3, Cote = "LIT-001" },
            new() { IdExemplaire = "EX008", IdEtat = 1, Cote = "HIS-001" },
            new() { IdExemplaire = "EX009", IdEtat = 4, Cote = "CHM-001" },
            new() { IdExemplaire = "EX010", IdEtat = 1, Cote = "DRT-001" },
            new() { IdExemplaire = "EX011", IdEtat = 1, Cote = "DRT-001" },
            new() { IdExemplaire = "EX012", IdEtat = 1, Cote = "DRT-001" },
            new() { IdExemplaire = "EX013", IdEtat = 1, Cote = "DRT-001" },
            new() { IdExemplaire = "EX014", IdEtat = 1, Cote = "DRT-001" },
            new() { IdExemplaire = "EX015", IdEtat = 1, Cote = "DRT-001" },
            new() { IdExemplaire = "EX016", IdEtat = 1, Cote = "INF-001" },

        };

        await context.Exemplaires.AddRangeAsync(exemplaires);
        await context.SaveChangesAsync();
    }
}
