using Borrowing.Api.Controllers;
using Borrowing.Api.Services;
using Moq;

namespace Borrowing.Api.Tests.Unit.Controllers;

public class PenaliteControllerTest
{
    private readonly Mock<IPenaliteService> _penaliteServiceMock = new();
    private readonly PenaliteController _sut;

    public PenaliteControllerTest()
    {
        _sut = new(_penaliteServiceMock.Object);
    }
}
