using Microsoft.EntityFrameworkCore;
using Common.Models;
using Common.Data;
namespace Common.Seeders;

public class CategorieSeeder : ISeeder
{
    public int Order => 1;

    public async Task SeedAsync(LibraryDbContext context)
    {
        var count = await context.Database
            .SqlQueryRaw<int>("SELECT COUNT(*) AS \"Value\" FROM MATAOUI.CATEGORIE")
            .FirstOrDefaultAsync();
        if (count > 0) return;

        var categories = new List<Categorie>
        {
            new() { IdCategorie = "ETU", LibelleCategorie = "Étudiant", NombreDocument = 3, DureePret = 14 },
            new() { IdCategorie = "ENS", LibelleCategorie = "Enseignant", NombreDocument = 5, DureePret = 30 },
            new() { IdCategorie = "DOC", LibelleCategorie = "Doctorant", NombreDocument = 5, DureePret = 21 },
            new() { IdCategorie = "ATS", LibelleCategorie = "Personnel ATS", NombreDocument = 3, DureePret = 14 },
            new() { IdCategorie = "EXT", LibelleCategorie = "Externe", NombreDocument = 2, DureePret = 7 }
        };

        await context.Categories.AddRangeAsync(categories);
        await context.SaveChangesAsync();
    }
}
