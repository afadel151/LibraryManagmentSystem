using Borrowing.Api.Controllers;
using Borrowing.Api.Repositories;
using Moq;

namespace Borrowing.Api.Tests.Unit.Controllers;

public class EtatAdherentControllerTest
{
    private readonly Mock<IEtatAdherentRepository> _etatAdherentRepositoryMock = new();
    private readonly EtatAdherentController _sut;

    public EtatAdherentControllerTest()
    {
        _sut = new(_etatAdherentRepositoryMock.Object);
    }
}
