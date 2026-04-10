using Borrowing.Api.Controllers;
using Borrowing.Api.Services;
using Moq;

namespace Borrowing.Api.Tests.Unit.Controllers;

public class JoursFeriesControllerTest
{
    private readonly Mock<IJoursFeriesService> _joursFeriesServiceMock = new();
    private readonly JoursFeriesController _sut;

    public JoursFeriesControllerTest()
    {
        _sut = new(_joursFeriesServiceMock.Object);
    }
}
