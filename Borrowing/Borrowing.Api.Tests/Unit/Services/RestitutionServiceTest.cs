using Borrowing.Api.Repositories;
using Borrowing.Api.Services;
using Moq;

namespace Borrowing.Api.Tests.Unit.Services;

public class RestitutionServiceTest
{
    private readonly Mock<IPretRepository> _pretRepositoryMock = new();
    private readonly Mock<IExemplairesRepository> _exemplairesRepositoryMock = new();
    private readonly Mock<IPenaliteAdherentRepository> _penaliteAdherentRepositoryMock = new();
    private readonly Mock<IAdherentRepository> _adherentRepositoryMock = new();
    private readonly RestitutionService _sut;

    public RestitutionServiceTest()
    {
        _sut = new(
            _pretRepositoryMock.Object,
            _exemplairesRepositoryMock.Object,
            _penaliteAdherentRepositoryMock.Object,
            _adherentRepositoryMock.Object
        );
    }
}
