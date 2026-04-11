using Borrowing.Api.Repositories;
using Borrowing.Api.Services;
using FluentAssertions;
using Moq;
using LibraryManagement.Shared.Models;
using Borrowing.Api.Tests.Helpers;
namespace Borrowing.Api.Tests.Unit.Services;

public class CategorieServiceTests
{
    private readonly Mock<ICategorieRepository> _categorieRepositoryMock = new();
    private readonly CategorieService _sut;

    public CategorieServiceTests()
    {
        _sut = new(_categorieRepositoryMock.Object);
    }

    [Fact]
    public async Task GetAllCategoriesAsync_WhenCategoriesExist_ReturnsMappedDtos()
    {
        // Arrange
        var categories = new List<Categorie>
        {
            new() { IdCategorie = "C1", LibelleCategorie = "Etudiant" },
            new() { IdCategorie = "C2", LibelleCategorie = "Enseignant" }
        };

        var mockQueryable = new TestAsyncQueryable<Categorie>(categories);
        _categorieRepositoryMock
            .Setup(r => r.GetQueryable())
            .Returns(mockQueryable);

        // Act
        var result = await _sut.GetAllCategoriesAsync();

        // Assert
        result.Should().HaveCount(2);
        result.Should().ContainSingle(c => c.IdCategorie == "C1" && c.LibelleCategorie == "Etudiant");
        result.Should().ContainSingle(c => c.IdCategorie == "C2" && c.LibelleCategorie == "Enseignant");
    }

    [Fact]
    public async Task GetAllCategoriesAsync_WhenNoCategories_ReturnsEmptyList()
    {
        // Arrange
        var mockQueryable = new TestAsyncQueryable<Categorie>([]);
        _categorieRepositoryMock
            .Setup(r => r.GetQueryable())
            .Returns(mockQueryable);

        // Act
        var result = await _sut.GetAllCategoriesAsync();

        // Assert
        result.Should().BeEmpty();
    }

    [Fact]
    public async Task GetAllCategoriesAsync_WhenLibelleCategorieIsNull_MapsToEmptyString()
    {
        // Arrange
        var categories = new List<Categorie>
        {
            new() { IdCategorie = "C1", LibelleCategorie = null }
        };

        var mockQueryable = new TestAsyncQueryable<Categorie>(categories);
        _categorieRepositoryMock
            .Setup(r => r.GetQueryable())
            .Returns(mockQueryable);

        // Act
        var result = await _sut.GetAllCategoriesAsync();

        // Assert
        result.Should().ContainSingle(c => c.LibelleCategorie == string.Empty);
    }
}