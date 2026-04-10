using Borrowing.Api.Repositories;
using Borrowing.Api.Services;
using Moq;

namespace Borrowing.Api.Tests.Unit.Services;

public class PenaliteServiceTest
{
    private readonly Mock<IPenaliteRepository> _penaliteRepositoryMock = new();
    private readonly Mock<ICategorieRepository> _categorieRepositoryMock = new();
    private readonly PenaltieService _sut;

    public PenaliteServiceTest()
    {
        _sut = new(
            _penaliteRepositoryMock.Object,
            _categorieRepositoryMock.Object
        );
    }
}
