using Shared.Data;

namespace Shared.Seeders;


public class DatabaseSeeder
{
    private readonly LibraryDbContext _context;
    private readonly List<ISeeder> _seeders;

    public DatabaseSeeder(LibraryDbContext context)
    {
        _context = context;
        _seeders = new List<ISeeder>
        {
            // lvl 1 
            new EtatAdherentSeeder(),
            new EtatExemplaireSeeder(),
            new CategorieSeeder(),
            new PositionSeeder(),
            new TypeNoticeSeeder(),
            new JoursFerySeeder(),

            // lvl 2
            new AdherentSeeder(),
            new ExemplaireSeeder(),
            new NoticeSeeder(),
            new PenaliteSeeder(),

            // lvl 3
            new PretSeeder(),
            new ReservationSeeder(),
            new PenaliteAdherentSeeder(),
            new HistoriquePretSeeder(),
            new HistoriquePenaliteAdherentSeeder(),
        };
    }

    public async Task SeedAllAsync()
    {
        foreach (var seeder in _seeders.OrderBy(s => s.Order))
        {
            await seeder.SeedAsync(_context);
        }
    }
}
