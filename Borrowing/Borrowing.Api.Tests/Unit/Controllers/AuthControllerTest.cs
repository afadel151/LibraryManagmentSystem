using Borrowing.Api.Controllers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Moq;

namespace Borrowing.Api.Tests.Unit.Controllers;

public class AuthControllerTest
{
    private readonly Mock<IConfiguration> _configMock = new();
    private readonly Mock<LibraryDbContext> _dbContextMock = new();
    private readonly AuthController _sut;

    public AuthControllerTest()
    {
        _sut = new(_configMock.Object, _dbContextMock.Object);
    }
}
