namespace Borrowing.Web.Services;

using Borrowing.SharedClasses.Requests.Pret;
using Borrowing.SharedClasses.Responses.Pret;
using Borrowing.SharedClasses.Responses.Adherent;
using Borrowing.SharedClasses.Responses.Notice;
using Borrowing.SharedClasses.Common;
using System.Threading.Tasks;

public interface IBorrowingService
{
    Task<PagedResult<PretResponseDto>> GetPretsAsync(PretQueryParameters queryParameters);
    Task<PretStatsDto> GetStats();
    Task<CheckAdhResponseDto> CheckAdherent(string id);
     Task<CheckNoticeResponseDto> CheckNotice(string cote, string AdherentId);
}
