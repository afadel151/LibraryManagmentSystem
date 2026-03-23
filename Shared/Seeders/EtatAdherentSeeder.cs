using Microsoft.EntityFrameworkCore;
using Shared.Data;
using Shared.Models;

namespace Shared.Seeders;

public class EtatAdherentSeeder : ISeeder
{
    public int Order => 1;

    public async Task SeedAsync(LibraryDbContext context)
    {
        if (await context.EtatAdherents.AnyAsync()) return;

        var etats = new List<EtatAdherent>
        {
            new() { IdEtat = false, DescEtat = "Inactif" },
            new() { IdEtat = true, DescEtat = "Actif" }
        };

        await context.EtatAdherents.AddRangeAsync(etats);
        await context.SaveChangesAsync();
    }
}
