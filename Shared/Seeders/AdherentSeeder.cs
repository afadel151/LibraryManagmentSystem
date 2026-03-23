using Microsoft.EntityFrameworkCore;
using Shared.Data;
using Shared.Models;

namespace Shared.Seeders;

public class AdherentSeeder : ISeeder
{
    public int Order => 2;

    public async Task SeedAsync(LibraryDbContext context)
    {
        if (await context.Adherents.AnyAsync()) return;

        var adherents = new List<Adherent>
        {
            new() { IdAdherent = "B/001", Nom = "Benali", Prenom = "Ahmed", IdPosition = 1, IdCategorie = "ETU", EtatAdherent = 1 },
            new() { IdAdherent = "B/002", Nom = "Boudjema", Prenom = "Fatima", IdPosition = 4, IdCategorie = "ETU", EtatAdherent = 1 },
            new() { IdAdherent = "B/003", Nom = "Khelifi", Prenom = "Mohamed", IdPosition = 6, IdCategorie = "DOC", EtatAdherent = 1 },
            new() { IdAdherent = "B/004", Nom = "Rahmani", Prenom = "Sara", IdPosition = 7, IdCategorie = "ENS", EtatAdherent = 1 },
            new() { IdAdherent = "C/001", Nom = "Cherif", Prenom = "Youcef", IdPosition = 2, IdCategorie = "ETU", EtatAdherent = 1 },
            new() { IdAdherent = "C/002", Nom = "Mebarki", Prenom = "Amina", IdPosition = 5, IdCategorie = "ETU", EtatAdherent = 0 },
            new() { IdAdherent = "C/003", Nom = "Touzani", Prenom = "Karim", IdPosition = 8, IdCategorie = "ENS", EtatAdherent = 1 },
            new() { IdAdherent = "C/004", Nom = "Haddad", Prenom = "Leila", IdPosition = 3, IdCategorie = "ETU", EtatAdherent = 1 },
        };

        await context.Adherents.AddRangeAsync(adherents);
        await context.SaveChangesAsync();
    }
}
