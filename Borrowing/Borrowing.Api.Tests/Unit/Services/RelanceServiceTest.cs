using Borrowing.Api.Repositories;
using Borrowing.Api.Services;
using Moq;

namespace Borrowing.Api.Tests.Unit.Services;

public class RelanceServiceTest
{
    private readonly Mock<IPretRepository> _pretRepositoryMock = new();
    private readonly Mock<IAdherentRepository> _adherentRepositoryMock = new();
    private readonly RelanceService _sut;

    public RelanceServiceTest()
    {
        _sut = new(
            _pretRepositoryMock.Object,
            _adherentRepositoryMock.Object
        );
    }
}
