using Microsoft.EntityFrameworkCore;
using Shared.Data;
using LibraryManagement.Common.Models;

namespace Shared.Seeders;

public class HistoriquePenaliteAdherentSeeder : ISeeder
{
    public int Order => 3;

    public async Task SeedAsync(LibraryDbContext context)
    {
        var count = await context.Database
            .SqlQueryRaw<int>("SELECT COUNT(*) AS \"Value\" FROM MATAOUI.HISTORIQUE_PENALITE_ADHERENT")
            .FirstOrDefaultAsync();
        if (count > 0) return;
        var historiques = new List<HistoriquePenaliteAdherent>
        {
            new() { IdAdherent = "C002", DatePenalite = new DateTime(2026, 2, 15), NombreJoursPenalite = 7 },
        };

        await context.HistoriquePenaliteAdherents.AddRangeAsync(historiques);
        await context.SaveChangesAsync();
    }
}
