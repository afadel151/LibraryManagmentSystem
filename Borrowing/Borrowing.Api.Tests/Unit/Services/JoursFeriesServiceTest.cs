using Borrowing.Api.Repositories;
using Borrowing.Api.Services;
using Borrowing.Api.Tests.Helpers;
using Borrowing.SharedClasses.Requests.JoursFery;
using FluentAssertions;
using Moq;
using Common.Models;
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


    [Fact]
    public async Task GetAllJoursFeriesAsync_WhenDataDoesntExist_ReturnEmptyList()
    {
        _joursFeriesRepositoryMock.Setup(r => r.GetQueryable()).Returns(new TestAsyncQueryable<JoursFery>([]));

        var result = await _sut.GetAllJoursFeriesAsync();

        result.Should().HaveCount(0);
    }

    [Fact]
    public async Task CreateJoursFeryAsync_WhenAlreadyExists_ReturnFalse()
    {
        // Arrange
        var date = new DateTime(2025, 1, 1);
        var existing = new List<JoursFery>
        {
            new() { DateJourFerie = date }
        };
        _joursFeriesRepositoryMock
            .Setup(r => r.GetQueryable())
            .Returns(new TestAsyncQueryable<JoursFery>(existing));
        // Act
        var result = await _sut.CreateJoursFeryAsync(new CreateJoursFeryDto { DateJourFerie = date });

        //assert
        result.Should().BeFalse();
        _joursFeriesRepositoryMock.Verify(r => r.AddAsync(It.IsAny<JoursFery>()), Times.Never);
    }
    [Fact]
    public async Task CreateJoursFeryAsync_WhenNotExists_ReturnsTrue()
    {
        // arrange
        var date = new DateTime(2025, 1, 1);
        var existing = new List<JoursFery>
        {
            new() { DateJourFerie = date }
        };
        _joursFeriesRepositoryMock
            .Setup(r => r.GetQueryable())
            .Returns(new TestAsyncQueryable<JoursFery>(existing));

        _joursFeriesRepositoryMock
            .Setup(r => r.AddAsync(It.IsAny<JoursFery>()))
            .Returns(Task.CompletedTask);

        // act
        var result = await _sut.CreateJoursFeryAsync(
            new CreateJoursFeryDto { DateJourFerie = new DateTime(2025, 6, 19) });

        // assert
        result.Should().BeTrue();
        _joursFeriesRepositoryMock.Verify(r => r.AddAsync(It.IsAny<JoursFery>()), Times.Once);
    }
    [Fact]
    public async Task CreateJoursFeryAsync_WhenRepoThrows_ReturnsFalse()
    {
        // Arrange
        _joursFeriesRepositoryMock
            .Setup(r => r.GetQueryable())
            .Returns(new TestAsyncQueryable<JoursFery>([]));
            
        _joursFeriesRepositoryMock
            .Setup(r => r.AddAsync(It.IsAny<JoursFery>()))
            .ThrowsAsync(new Exception("DB error"));

        // Act
        var result = await _sut.CreateJoursFeryAsync(
            new CreateJoursFeryDto { DateJourFerie = new DateTime(2025, 6, 19) });

        // Assert
        result.Should().BeFalse();
    }
}