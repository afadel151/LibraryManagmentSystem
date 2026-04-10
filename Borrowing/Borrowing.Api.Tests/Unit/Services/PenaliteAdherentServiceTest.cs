using Borrowing.Api.Repositories;
using Borrowing.Api.Services;
using Moq;

namespace Borrowing.Api.Tests.Unit.Services;

public class PenaliteAdherentServiceTest
{
    private readonly Mock<IPenaliteRepository> _penaliteRepositoryMock = new();
    private readonly Mock<IPenaliteAdherentRepository> _penaliteAdherentRepositoryMock = new();
    private readonly Mock<IHistoriquePenaliteAdherentRepository> _historiquePenaliteAdherentRepositoryMock = new();
    private readonly Mock<IPenaliteAdherentTempRepository> _penaliteAdherentTempRepositoryMock = new();
    private readonly PenaltieAdherentService _sut;

    public PenaliteAdherentServiceTest()
    {
        _sut = new(
            _penaliteRepositoryMock.Object,
            _penaliteAdherentRepositoryMock.Object,
            _historiquePenaliteAdherentRepositoryMock.Object,
            _penaliteAdherentTempRepositoryMock.Object
        );
    }
}
