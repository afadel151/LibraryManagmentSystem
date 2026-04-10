using Borrowing.Api.Controllers;
using Borrowing.Api.Services;
using Moq;

namespace Borrowing.Api.Tests.Unit.Controllers;

public class PenaliteAdherentControllerTest
{
    private readonly Mock<IPenaliteAdherentService> _penaliteAdherentServiceMock = new();
    private readonly PenaliteAdherentController _sut;

    public PenaliteAdherentControllerTest()
    {
        _sut = new(_penaliteAdherentServiceMock.Object);
    }
}
