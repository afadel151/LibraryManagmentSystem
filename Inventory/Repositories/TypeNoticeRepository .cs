using Common.Models;
using Common.Data;
using Microsoft.EntityFrameworkCore;

namespace Inventory.Repositories;

public interface ITypeNoticeRepository : IBaseRepository<TypeNotice>
{

}
public class TypeNoticeRepository(LibraryDbContext context) : BaseRepository<TypeNotice>(context), ITypeNoticeRepository
{
    
}
