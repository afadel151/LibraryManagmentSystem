using Microsoft.EntityFrameworkCore;
using Common.Models;
using Common.Data;
namespace Common.Seeders;

public class EtatAdherentSeeder : ISeeder
{
    public int Order => 1;

    public async Task SeedAsync(LibraryDbContext context)
    {
        var count = await context.Database
            .SqlQueryRaw<int>("SELECT COUNT(*) AS \"Value\" FROM MATAOUI.ETAT_ADHERENT")
            .FirstOrDefaultAsync();

        if (count > 0) return;

        await context.Database.ExecuteSqlRawAsync(
            "INSERT INTO MATAOUI.ETAT_ADHERENT (ID_ETAT, DESC_ETAT) VALUES (0, 'Inactif')");
        await context.Database.ExecuteSqlRawAsync(
            "INSERT INTO MATAOUI.ETAT_ADHERENT (ID_ETAT, DESC_ETAT) VALUES (1, 'Actif')");
    }
}
