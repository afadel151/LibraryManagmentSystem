using Borrowing.Api.Repositories;
using Borrowing.Api.Services;
using Borrowing.Api.Tests.Helpers;
using Borrowing.SharedClasses.Requests.JoursFery;
using FluentAssertions;
using Moq;
using Shared.Models;
namespace Borrowing.Api.Tests.Unit.Services;

public class JoursFeriesServiceTest
{
    private readonly Mock<IJoursFeriesRepository> _joursFeriesRepositoryMock = new();
    private readonly JoursFeriesService _sut;

    public JoursFeriesServiceTest()
    {
        _sut = new(_joursFeriesRepositoryMock.Object);
    }

    [Fact]
    public async Task GetAllJoursFeriesAsync_WhenDataExists_ReturnsSortedDtos()
    {
        // Arrange
        var data = new List<JoursFery>
        {
            new() { DateJourFerie = new DateTime(2025, 12, 25) },
            new() { DateJourFerie = new DateTime(2025, 1, 1) }
        };
        _joursFeriesRepositoryMock.Setup(r => r.GetQueryable()).Returns(new TestAsyncQueryable<JoursFery>(data));

        // Act
        var result = await _sut.GetAllJoursFeriesAsync();

        // Assert
        result.Should().HaveCount(2);
        result.First().DateJourFerie.Should().Be(new DateTime(2025, 1, 1)); // sorted asc
    }

}