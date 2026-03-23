using Shared.Data;

namespace Shared.Seeders;

public interface ISeeder
{
    int Order { get; }
    Task SeedAsync(LibraryDbContext context);
}
