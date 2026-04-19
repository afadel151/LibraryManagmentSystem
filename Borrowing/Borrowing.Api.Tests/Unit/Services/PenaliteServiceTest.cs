using Borrowing.Api.Repositories;
using Borrowing.Api.Services;
using Microsoft.Extensions.Logging;
using Moq;

namespace Borrowing.Api.Tests.Unit.Services;

public class PenaliteServiceTest
{
    private readonly Mock<IPenaliteRepository> _penaliteRepositoryMock = new();
    private readonly PenaltieService _sut;
    private readonly Mock<ILogger<PenaltieService>> _logger = new();

    public PenaliteServiceTest()
    {
        _sut = new(
            _penaliteRepositoryMock.Object,
            _logger.Object
        );
    }
}
