using Borrowing.Api.Controllers;
using Borrowing.Api.Services;
using Moq;

namespace Borrowing.Api.Tests.Unit.Controllers;

public class NoticeControllerTest
{
    private readonly Mock<INoticeService> _noticeServiceMock = new();
    private readonly Mock<IPretService> _pretServiceMock = new();
    private readonly Mock<IReservationService> _reservationServiceMock = new();
    private readonly NoticeController _sut;

    public NoticeControllerTest()
    {
        _sut = new(
            _noticeServiceMock.Object
        );
    }
}
