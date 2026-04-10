using Borrowing.Api.Controllers;
using Borrowing.Api.Services;
using Moq;

namespace Borrowing.Api.Tests.Unit.Controllers;

public class RestitutionControllerTest
{
    private readonly Mock<IPretService> _pretServiceMock = new();
    private readonly RestitutionController _sut;

    public RestitutionControllerTest()
    {
        _sut = new(_pretServiceMock.Object);
    }
}
