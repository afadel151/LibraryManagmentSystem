using Borrowing.Api.Repositories;
using Borrowing.Api.Services;
using Moq;

namespace Borrowing.Api.Tests.Unit.Services;

public class PositionServiceTest
{
    private readonly Mock<IPositionRepository> _positionRepositoryMock = new();
    private readonly PositionService _sut;

    public PositionServiceTest()
    {
        _sut = new(_positionRepositoryMock.Object);
    }
}
