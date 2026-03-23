using Microsoft.EntityFrameworkCore;
using Shared.Data;
using Shared.Models;

namespace Shared.Seeders;

public class PositionSeeder : ISeeder
{
    public int Order => 1;

    public async Task SeedAsync(LibraryDbContext context)
    {
        var count = await context.Database
            .SqlQueryRaw<int>("SELECT COUNT(*) AS \"Value\" FROM MATAOUI.POSITION")
            .FirstOrDefaultAsync();
        if (count > 0) return;

        var positions = new List<Position>
        {
            new() { IdPosition = 1, LibellePosition = "Licence 1" },
            new() { IdPosition = 2, LibellePosition = "Licence 2" },
            new() { IdPosition = 3, LibellePosition = "Licence 3" },
            new() { IdPosition = 4, LibellePosition = "Master 1" },
            new() { IdPosition = 5, LibellePosition = "Master 2" },
            new() { IdPosition = 6, LibellePosition = "Doctorat" },
            new() { IdPosition = 7, LibellePosition = "Professeur" },
            new() { IdPosition = 8, LibellePosition = "Maître de conférences" }
        };

        await context.Positions.AddRangeAsync(positions);
        await context.SaveChangesAsync();
    }
}
