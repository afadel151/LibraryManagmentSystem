using Borrowing.Api.Repositories;
using Borrowing.Api.Services;
using Microsoft.Extensions.Logging;
using Moq;

namespace Borrowing.Api.Tests.Unit.Services;

public class PenaliteAdherentServiceTest
{
    private readonly Mock<IPenaliteAdherentRepository> _penaliteAdherentRepositoryMock = new();
    private readonly Mock<IHistoriquePenaliteAdherentRepository> _historiquePenaliteAdherentRepositoryMock = new();
    private readonly PenaltieAdherentService _sut;
    private readonly Mock<ILogger<PenaltieAdherentService>> _logger = new();

    public PenaliteAdherentServiceTest()
    {
        _sut = new(
            _penaliteAdherentRepositoryMock.Object,
            _historiquePenaliteAdherentRepositoryMock.Object,
            _logger.Object
        );
    }
}
