using Borrowing.Api.Repositories;
using Borrowing.Api.Services;
using Moq;

namespace Borrowing.Api.Tests.Unit.Services;

public class ReservationServiceTest
{
    private readonly Mock<IReservationRepository> _reservationRepositoryMock = new();
    private readonly Mock<IAdherentRepository> _adherentRepositoryMock = new();
    private readonly Mock<IPretRepository> _pretRepositoryMock = new();
    private readonly Mock<INoticesRepository> _noticesRepositoryMock = new();
    private readonly Mock<IExemplairesRepository> _exemplairesRepositoryMock = new();
    private readonly ReservationService _sut;

    public ReservationServiceTest()
    {
        _sut = new( 
            _reservationRepositoryMock.Object,
            _pretRepositoryMock.Object,
            _noticesRepositoryMock.Object
        );
    }
}
