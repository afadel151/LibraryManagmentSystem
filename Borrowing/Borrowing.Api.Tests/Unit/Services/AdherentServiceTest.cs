using Borrowing.Api.Repositories;
using Borrowing.Api.Services;
using Moq;

namespace Borrowing.Api.Tests.Unit.Services;

public class AdherentServiceTest
{
    private readonly Mock<IAdherentRepository> _adherentRepositoryMock = new();
    private readonly Mock<IReservationRepository> _reservationRepositoryMock = new();
    private readonly Mock<IPenaliteAdherentRepository> _penaliteAdherentRepositoryMock = new();
    private readonly Mock<ICategorieRepository> _categorieRepositoryMock = new();
    private readonly Mock<IJoursFeriesRepository> _joursFeriesRepositoryMock = new();
    private readonly Mock<IPretRepository> _pretRepositoryMock = new();
    private readonly AdherentService _sut;

    public AdherentServiceTest()
    {
        _sut = new(
            _adherentRepositoryMock.Object,
            _reservationRepositoryMock.Object,
            _penaliteAdherentRepositoryMock.Object,
            _categorieRepositoryMock.Object,
            _joursFeriesRepositoryMock.Object,
            _pretRepositoryMock.Object
        );
    }
}