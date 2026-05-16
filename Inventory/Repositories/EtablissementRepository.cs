using Common.Models;
using Common.Data;
namespace Inventory.Repositories;

public interface IEtablissementRepository : IBaseRepository<Etablissement>
{
}
public class EtablissementRepository(LibraryDbContext context) : BaseRepository<Etablissement>(context), IEtablissementRepository
{
}
