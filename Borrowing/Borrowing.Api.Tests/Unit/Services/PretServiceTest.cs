using Borrowing.Api.Repositories;
using Borrowing.Api.Services;
using Moq;

namespace Borrowing.Api.Tests.Unit.Services;

public class PretServiceTest
{
    private readonly Mock<IPretRepository> _pretRepositoryMock = new();
    private readonly Mock<IHistoriquePretRepository> _historiquePretRepositoryMock = new ();
    private readonly Mock<IExemplairesRepository> _exemplaireReositoryMock = new();
    private readonly Mock<IAdherentRepository> _adherentRepositoryMock = new ();
    private readonly Mock<IPositionRepository> _positionRepositoryMock = new ();
    private readonly Mock<ICategorieRepository> _categorieRepositoryMock = new ();
    private readonly Mock<IPenaliteAdherentRepository> _penaliteAdherentRepositoryMock = new ();
    private readonly Mock<IPenaliteRepository> _penaliteRepositoryMock = new ();
    private readonly Mock<IJoursFeriesRepository> _jooursFeriesRepositoryMock = new ();
    private readonly Mock<IReservationRepository> _reservationRepositoryMock = new ();
    private readonly Mock<INoticesRepository> _noticeRepositoryMock = new ();
    private readonly PretService _sut;

    public PretServiceTest()
    {
        _sut = new(
            _pretRepositoryMock.Object,
            _historiquePretRepositoryMock.Object,
            _exemplaireReositoryMock.Object,
            _adherentRepositoryMock.Object,
            _positionRepositoryMock.Object,
            _categorieRepositoryMock.Object,
            _penaliteAdherentRepositoryMock.Object,
            _penaliteRepositoryMock.Object,
            _jooursFeriesRepositoryMock.Object,
            _reservationRepositoryMock.Object,
            _noticeRepositoryMock.Object
            );
    }


}