using Microsoft.EntityFrameworkCore;
using Shared.Data;
using Shared.Models;

namespace Shared.Seeders;

public class PenaliteAdherentSeeder : ISeeder
{
    public int Order => 3;

    public async Task SeedAsync(LibraryDbContext context)
    {
        if (await context.PenaliteAdherents.AnyAsync()) return;

        var penalitesAdherents = new List<PenaliteAdherent>
        {
            new() { IdAdherent = "ADH006", DatePenalite = new DateTime(2026, 2, 15), NombreJoursPenalite = 7 },
        };

        await context.PenaliteAdherents.AddRangeAsync(penalitesAdherents);
        await context.SaveChangesAsync();
    }
}
