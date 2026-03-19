using Borrowing.Api.Repositories;
using Shared.Models;

namespace Borrowing.Api.Services;

public interface INoticeService
{
    Task<Notice?> GetNoticeWithExemplairesAsync(int noticeId);
}

public class NoticeService : INoticeService
{
    private readonly INoticesRepository _noticesRepository;
    private readonly IExemplairesRepository _exemplairesRepository;

    public NoticeService(
        INoticesRepository noticesRepository, 
        IExemplairesRepository exemplairesRepository)
    {
        _noticesRepository = noticesRepository;
        _exemplairesRepository = exemplairesRepository;
    }

    // Sample method to demonstrate repository usage
    public async Task<Notice?> GetNoticeWithExemplairesAsync(int noticeId)
    {
        // Example: retrieve notice
        // var notice = await _noticesRepository.GetByIdAsync(noticeId);
        // return notice;
        return null;
    }
}