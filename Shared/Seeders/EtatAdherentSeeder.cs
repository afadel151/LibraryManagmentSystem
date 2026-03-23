using Microsoft.EntityFrameworkCore;
using Shared.Data;
using Shared.Models;

namespace Shared.Seeders;

public class EtatAdherentSeeder : ISeeder
{
    public int Order => 1;

    public async Task SeedAsync(LibraryDbContext context)
    {
        var count = await context.Database
            .SqlQueryRaw<int>("SELECT COUNT(*) AS \"Value\" FROM MATAOUI.ETAT_ADHERENT")
            .FirstOrDefaultAsync();

        if (count > 0) return;

        var etats = new List<EtatAdherent>
        {
            new() { IdEtat = 0, DescEtat = "Inactif" },
            new() { IdEtat = 1, DescEtat = "Actif" }
        };

        await context.EtatAdherents.AddRangeAsync(etats);
        await context.SaveChangesAsync();
    }
}
