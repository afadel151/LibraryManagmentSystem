using Microsoft.EntityFrameworkCore;
using Common.Data;
using Common.Models;

namespace Common.Seeders;

public class EtatExemplaireSeeder : ISeeder
{
    public int Order => 1;

    public async Task SeedAsync(LibraryDbContext context)
    {
        ArgumentNullException.ThrowIfNull(context);
        var count = await context.Database
            .SqlQueryRaw<int>("SELECT COUNT(*) AS \"Value\" FROM MATAOUI.ETAT_EXEMPLAIRE")
            .FirstOrDefaultAsync();
        if (count > 0) return;

        var etats = new List<EtatExemplaire>
        {
            new() { IdEtat = 1, LibelleEtat = "Disponible" },
            new() { IdEtat = 2, LibelleEtat = "Emprunté" },
            new() { IdEtat = 3, LibelleEtat = "Réservé" },
            new() { IdEtat = 4, LibelleEtat = "Endommagé" },
            new() { IdEtat = 5, LibelleEtat = "Perdu" }
        };

        await context.EtatExemplaires.AddRangeAsync(etats);
        await context.SaveChangesAsync();
    }
}
