using Microsoft.EntityFrameworkCore;
using Common.Models;

namespace Common.Seeders;
using Common.Data;
public class PenaliteAdherentSeeder : ISeeder
{
    public int Order => 3;

    public async Task SeedAsync(LibraryDbContext context)
    {  ArgumentNullException.ThrowIfNull(context);
        var count = await context.Database
            .SqlQueryRaw<int>("SELECT COUNT(*) AS \"Value\" FROM MATAOUI.PENALITE_ADHERENT")
            .FirstOrDefaultAsync();
        if (count > 0) return;

        var penalitesAdherents = new List<PenaliteAdherent>
        {
            new() { IdAdherent = "B001", DatePenalite = new DateTime(2026, 2, 15), NombreJoursPenalite = 7 },
        };

        await context.PenaliteAdherents.AddRangeAsync(penalitesAdherents);
        await context.SaveChangesAsync();
    }
}
