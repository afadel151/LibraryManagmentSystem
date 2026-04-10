using Borrowing.Api.Controllers;
using Borrowing.Api.Services;
using Moq;

namespace Borrowing.Api.Tests.Unit.Controllers;

public class PositionControllerTest
{
    private readonly Mock<IPositionService> _positionServiceMock = new();
    private readonly PositionController _sut;

    public PositionControllerTest()
    {
        _sut = new(_positionServiceMock.Object);
    }
}
