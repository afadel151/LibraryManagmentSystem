using Microsoft.EntityFrameworkCore;
using Common.Models;
using Common.Data;

namespace Common.Seeders;

public class AdherentSeeder : ISeeder
{
    public int Order => 2;

    public async Task SeedAsync(LibraryDbContext context)
    {  ArgumentNullException.ThrowIfNull(context);
        var count = await context.Database
            .SqlQueryRaw<int>("SELECT COUNT(*) AS \"Value\" FROM MATAOUI.ADHERENT")
            .FirstOrDefaultAsync();
        if (count > 0) return;

        var adherents = new List<Adherent>
        {
            new() { IdAdherent = "B001", Nom = "Benali", Prenom = "Ahmed", IdPosition = 1, IdCategorie = "ETU", EtatAdherent = 1 },
            new() { IdAdherent = "B002", Nom = "Boudjema", Prenom = "Fatima", IdPosition = 4, IdCategorie = "ETU", EtatAdherent = 1 },
            new() { IdAdherent = "B003", Nom = "Khelifi", Prenom = "Mohamed", IdPosition = 6, IdCategorie = "DOC", EtatAdherent = 1 },
            new() { IdAdherent = "B004", Nom = "Rahmani", Prenom = "Sara", IdPosition = 7, IdCategorie = "ENS", EtatAdherent = 1 },
            new() { IdAdherent = "C001", Nom = "Cherif", Prenom = "Youcef", IdPosition = 2, IdCategorie = "ETU", EtatAdherent = 1 },
            new() { IdAdherent = "C002", Nom = "Mebarki", Prenom = "Amina", IdPosition = 5, IdCategorie = "ETU", EtatAdherent = 0 },
            new() { IdAdherent = "C003", Nom = "Touzani", Prenom = "Karim", IdPosition = 8, IdCategorie = "ENS", EtatAdherent = 1 },
            new() { IdAdherent = "C004", Nom = "Haddad", Prenom = "Leila", IdPosition = 3, IdCategorie = "ETU", EtatAdherent = 1 },
        };

        await context.Adherents.AddRangeAsync(adherents);
        await context.SaveChangesAsync();
    }
}
