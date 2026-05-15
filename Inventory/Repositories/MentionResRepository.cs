using Common.Models;
using Common.Data;
namespace Inventory.Repositories;

public interface IMentionResRepository : IBaseRepository<MentionResponsabilite>
{
}
public class MentionResRepository(LibraryDbContext context) : BaseRepository<MentionResponsabilite>(context), IMentionResRepository
{
}
