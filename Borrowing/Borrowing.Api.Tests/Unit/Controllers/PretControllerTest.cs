using Borrowing.Api.Controllers;
using Borrowing.Api.Services;
using Moq;

namespace Borrowing.Api.Tests.Unit.Controllers;

public class PretControllerTest
{
    private readonly Mock<IPretService> _pretServiceMock = new();
    private readonly Mock<IPenaliteAdherentService> _penaliteAdherentServiceMock = new();
    private readonly Mock<IAdherentService> _adherentServiceMock = new();
    private readonly Mock<INoticeService> _noticeServiceMock = new();
    private readonly Mock<IReservationService> _reservationServiceMock = new();
    private readonly PretController _sut;

    public PretControllerTest()
    {
        _sut = new(
            _pretServiceMock.Object,
            _penaliteAdherentServiceMock.Object,
            _adherentServiceMock.Object,
            _noticeServiceMock.Object,
            _reservationServiceMock.Object
        );
    }
}
