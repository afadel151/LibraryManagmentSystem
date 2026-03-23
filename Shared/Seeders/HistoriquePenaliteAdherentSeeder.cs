using Microsoft.EntityFrameworkCore;
using Shared.Data;
using Shared.Models;

namespace Shared.Seeders;

public class HistoriquePenaliteAdherentSeeder : ISeeder
{
    public int Order => 3;

    public async Task SeedAsync(LibraryDbContext context)
    {
        if (await context.HistoriquePenaliteAdherents.AnyAsync()) return;

        var historiques = new List<HistoriquePenaliteAdherent>
        {
            new() { IdAdherent = "ADH006", DatePenalite = new DateTime(2026, 2, 15), NombreJoursPenalite = 7 },
        };

        await context.HistoriquePenaliteAdherents.AddRangeAsync(historiques);
        await context.SaveChangesAsync();
    }
}
