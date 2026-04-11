using Microsoft.EntityFrameworkCore;
using Shared.Data;
using LibraryManagement.Shared.Models;

namespace Shared.Seeders;

public class PenaliteSeeder : ISeeder
{
    public int Order => 2;

    public async Task SeedAsync(LibraryDbContext context)
    {
        var count = await context.Database
            .SqlQueryRaw<int>("SELECT COUNT(*) AS \"Value\" FROM MATAOUI.PENALITE")
            .FirstOrDefaultAsync();
        if (count > 0) return;

        var penalites = new List<Penalite>
        {
            // Étudiant penalties
            new() { IdCategorie = "ETU", JoursRetard = 1, NombreJoursRetard = 2 },
            new() { IdCategorie = "ETU", JoursRetard = 7, NombreJoursRetard = 7 },
            new() { IdCategorie = "ETU", JoursRetard = 14, NombreJoursRetard = 14 },
            // Enseignant penalties
            new() { IdCategorie = "ENS", JoursRetard = 1, NombreJoursRetard = 1 },
            new() { IdCategorie = "ENS", JoursRetard = 7, NombreJoursRetard = 3 },
            new() { IdCategorie = "ENS", JoursRetard = 14, NombreJoursRetard = 7 },
            // Doctorant penalties
            new() { IdCategorie = "DOC", JoursRetard = 1, NombreJoursRetard = 1 },
            new() { IdCategorie = "DOC", JoursRetard = 7, NombreJoursRetard = 5 },
            new() { IdCategorie = "DOC", JoursRetard = 14, NombreJoursRetard = 10 },
        };

        await context.Penalites.AddRangeAsync(penalites);
        await context.SaveChangesAsync();
    }
}
