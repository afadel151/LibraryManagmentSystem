using Borrowing.Api.Controllers;
using Borrowing.Api.Services;
using Moq;

namespace Borrowing.Api.Tests.Unit.Controllers;

public class AdherentControllerTest
{
    private readonly Mock<IAdherentService> _adherentServiceMock = new();
    private readonly AdherentController _sut;

    public AdherentControllerTest()
    {
        _sut = new(_adherentServiceMock.Object);
    }

}
