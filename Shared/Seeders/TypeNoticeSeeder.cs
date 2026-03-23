using Microsoft.EntityFrameworkCore;
using Shared.Data;
using Shared.Models;

namespace Shared.Seeders;

public class TypeNoticeSeeder : ISeeder
{
    public int Order => 1;

    public async Task SeedAsync(LibraryDbContext context)
    {
        var count = await context.Database
            .SqlQueryRaw<int>("SELECT COUNT(*) AS \"Value\" FROM MATAOUI.TYPE_NOTICE")
            .FirstOrDefaultAsync();
        if (count > 0) return;
        var types = new List<TypeNotice>
        {
            new() { IdType = 1, TypeNotice1 = "Livre" },
            new() { IdType = 2, TypeNotice1 = "Thèse" },
            new() { IdType = 3, TypeNotice1 = "Mémoire" },
            new() { IdType = 4, TypeNotice1 = "Article" },
            new() { IdType = 5, TypeNotice1 = "Revue" },
            new() { IdType = 6, TypeNotice1 = "Rapport" },
            new() { IdType = 7, TypeNotice1 = "Ressource électronique" }
        };

        await context.TypeNotices.AddRangeAsync(types);
        await context.SaveChangesAsync();
    }
}
