using Borrowing.Api.Repositories;
using Borrowing.Api.Services;
using Microsoft.Extensions.Logging;
using Moq;

namespace Borrowing.Api.Tests.Unit.Services;

public class NoticeServiceTest
{
    private readonly Mock<INoticesRepository> _noticesRepositoryMock = new();
    private readonly Mock<IExemplairesRepository> _exemplairesRepositoryMock = new();
    private readonly Mock<IReservationRepository> _reservationRepositoryMock = new();
    private readonly Mock<IPretRepository> _pretRepositoryMock = new();
    private readonly Mock<IHistoriquePretRepository> _historiquePretRepositoryMock = new();
    private readonly NoticeService _sut;
    private readonly Mock<ILogger<NoticeService>> _logger = new();

    public NoticeServiceTest()
    {
        _sut = new(
            _noticesRepositoryMock.Object,
            _exemplairesRepositoryMock.Object,
            _reservationRepositoryMock.Object,
            _pretRepositoryMock.Object,
            _historiquePretRepositoryMock.Object,
            _logger.Object
        );
    }
}