using Borrowing.Api.Controllers;
using Borrowing.Api.Services;
using Moq;

namespace Borrowing.Api.Tests.Unit.Controllers;

public class ReservationControllerTest
{
    private readonly Mock<IReservationService> _reservationServiceMock = new();
    private readonly ReservationController _sut;

    public ReservationControllerTest()
    {
        _sut = new(_reservationServiceMock.Object);
    }
}
