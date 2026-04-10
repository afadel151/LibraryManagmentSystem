using Borrowing.Api.Controllers;
using Borrowing.Api.Services;
using Moq;

namespace Borrowing.Api.Tests.Unit.Controllers;

public class CategorieControllerTest
{
    private readonly Mock<ICategorieService> _categorieServiceMock = new();
    private readonly CategorieController _sut;

    public CategorieControllerTest()
    {
        _sut = new(_categorieServiceMock.Object);
    }
}
