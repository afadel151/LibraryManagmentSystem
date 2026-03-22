namespace Borrowing.Web.Services;

using Borrowing.Shared.Requests.Pret;
using Borrowing.Shared.Responses.Pret;
using System.Threading.Tasks;

public interface IBorrowingService
{
    Task<PagedResult<PretResponseDto>> GetPretsAsync(PretQueryParameters queryParameters);
}
