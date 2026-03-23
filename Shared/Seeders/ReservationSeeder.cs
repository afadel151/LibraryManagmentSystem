using Microsoft.EntityFrameworkCore;
using Shared.Data;
using Shared.Models;

namespace Shared.Seeders;

public class ReservationSeeder : ISeeder
{
    public int Order => 3;

    public async Task SeedAsync(LibraryDbContext context)
    {
        if (await context.Reservations.AnyAsync()) return;

        var reservations = new List<Reservation>
        {
            new() { IdAdherent = "ADH001", Cote = "MAT-001", HeureReservation = new DateTime(2026, 3, 20, 10, 0, 0) },
            new() { IdAdherent = "ADH005", Cote = "LIT-001", HeureReservation = new DateTime(2026, 3, 21, 14, 30, 0) },
        };

        await context.Reservations.AddRangeAsync(reservations);
        await context.SaveChangesAsync();
    }
}
