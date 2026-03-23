using Microsoft.EntityFrameworkCore;
using Shared.Data;
using Shared.Models;

namespace Shared.Seeders;

public class EtatExemplaireSeeder : ISeeder
{
    public int Order => 1;

    public async Task SeedAsync(LibraryDbContext context)
    {
        if (await context.EtatExemplaires.AnyAsync()) return;

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
