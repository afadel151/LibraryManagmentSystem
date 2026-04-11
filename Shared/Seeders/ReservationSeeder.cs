using Microsoft.EntityFrameworkCore;
using Shared.Data;
using LibraryManagement.Common.Models;

namespace Shared.Seeders;

public class ReservationSeeder : ISeeder
{
    public int Order => 3;

    public async Task SeedAsync(LibraryDbContext context)
    {
        var count = await context.Database
            .SqlQueryRaw<int>("SELECT COUNT(*) AS \"Value\" FROM MATAOUI.RESERVATION")
            .FirstOrDefaultAsync();
        if (count > 0) return;
        var reservations = new List<Reservation>
        {
            new() { IdAdherent = "B001", Cote = "MAT-001", HeureReservation = new DateTime(2026, 3, 20, 10, 0, 0) },
            new() { IdAdherent = "C001", Cote = "LIT-001", HeureReservation = new DateTime(2026, 3, 21, 14, 30, 0) },
        };

        await context.Reservations.AddRangeAsync(reservations);
        await context.SaveChangesAsync();
    }
}
