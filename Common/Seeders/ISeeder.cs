
using Common.Data;

namespace Common.Seeders;

public interface ISeeder
{
    int Order { get; }
    Task SeedAsync(LibraryDbContext context);
}
