using Microsoft.EntityFrameworkCore;
using Common.Models;
using Common.Data;

namespace Common.Seeders;
using Common.Data;
public class JoursFerySeeder : ISeeder
{
    public int Order => 1;

    public async Task SeedAsync(LibraryDbContext context)
    {
        var count = await context.Database
            .SqlQueryRaw<int>("SELECT COUNT(*) AS \"Value\" FROM MATAOUI.JOURS_FERIES")
            .FirstOrDefaultAsync();
        if (count > 0) return;

        var joursFeries = new List<JoursFery>
        {
            new() { DateJourFerie = new DateTime(2026, 1, 1) },   // Nouvel An
            new() { DateJourFerie = new DateTime(2026, 5, 1) },   // Fête du Travail
            new() { DateJourFerie = new DateTime(2026, 7, 5) },   // Fête de l'Indépendance
            new() { DateJourFerie = new DateTime(2026, 11, 1) },  // Toussaint
        };

        await context.JoursFeries.AddRangeAsync(joursFeries);
        await context.SaveChangesAsync();
    }
}
