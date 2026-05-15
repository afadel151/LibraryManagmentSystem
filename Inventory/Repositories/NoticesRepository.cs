using Common.Models;
using Common.Data;
using Microsoft.EntityFrameworkCore;

namespace Inventory.Repositories;

public interface INoticeRepository : IBaseRepository<Notice>
{
    Task<int> CountNonIndexeesAsync();
    Task<int> CountSansExemplaireAsync();
    Task<IEnumerable<Notice>> GetRecentAsync(int count);
    Task<IEnumerable<(decimal IdType, int Total, int NonIndexees, int SansExemplaire)>> GetStatsByTypeAsync();
}
public class NoticeRepository(LibraryDbContext context) : BaseRepository<Notice>(context), INoticeRepository
{
    protected new readonly DbSet<Notice> _dbSet = context.Set<Notice>();
    public Task<int> CountNonIndexeesAsync()
        => _dbSet.CountAsync(n => n.IsIndexed == 0);

    public Task<int> CountSansExemplaireAsync()
        => _dbSet.CountAsync(n => n.ExemplaireExiste == 0 && n.Accessibilite == "1");

    public Task<IEnumerable<Notice>> GetRecentAsync(int count)
        => Task.FromResult<IEnumerable<Notice>>(
            _dbSet
                .OrderByDescending(n => n.IdNotice)
                .Take(count)
                .AsEnumerable());

    public async Task<IEnumerable<(decimal IdType, int Total, int NonIndexees, int SansExemplaire)>> GetStatsByTypeAsync()
    {
        var stats = await _dbSet
            .GroupBy(n => n.IdType)
            .Select(g => new
            {
                IdType = g.Key,
                Total = g.Count(),
                NonIndexees = g.Count(n => n.IsIndexed == 0),
                SansExemplaire = g.Count(n => n.ExemplaireExiste == 0 && n.Accessibilite == "1"),
            })
            .ToListAsync();

        return stats.Select(s => (s.IdType, s.Total, s.NonIndexees, s.SansExemplaire));
    }
}
