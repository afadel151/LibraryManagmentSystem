using Borrowing.Api.Repositories;
using Borrowing.Api.Services;
using Borrowing.Api.Tests.Helpers;
using Borrowing.SharedClasses.Common;
using Moq;
using LibraryManagement.Common.Models;
using System.Linq.Expressions;
namespace Borrowing.Api.Tests.Unit.Services;

public class AdherentServiceTest
{
    private readonly Mock<IAdherentRepository> _adherentRepositoryMock = new();
    private readonly Mock<IReservationRepository> _reservationRepositoryMock = new();
    private readonly Mock<IPenaliteAdherentRepository> _penaliteAdherentRepositoryMock = new();
    private readonly Mock<ICategorieRepository> _categorieRepositoryMock = new();
    private readonly Mock<IJoursFeriesRepository> _joursFeriesRepositoryMock = new();
    private readonly Mock<IPretRepository> _pretRepositoryMock = new();
    private readonly AdherentService _sut;

    public AdherentServiceTest()
    {
        _sut = new(
            _adherentRepositoryMock.Object,
            _reservationRepositoryMock.Object,
            _penaliteAdherentRepositoryMock.Object,
            _categorieRepositoryMock.Object,
            _joursFeriesRepositoryMock.Object,
            _pretRepositoryMock.Object
        );
    }



    public class CreateAdherentAsyncTests : AdherentServiceTest
    {
        /*
        ├── Repository succeeds    → returns true
        └── Repository throws      → returns false
        */
    }

    public class CalculateExpectedReturnDateTests : AdherentServiceTest
    {
        /*
        ├── Return date lands on a regular weekday      → no adjustment
        ├── Return date lands on a public holiday       → skips it
        ├── Multiple consecutive holidays               → skips all
        ├── Empty holidays list                         → rawReturnDate returned as-is
        */
    }

    public class CheckAdherentPourPretTests : AdherentServiceTest
    {
        public class AdherentCheckTestCases : TheoryData<Adherent?, CheckAdherentEnum, List<JoursFery>>
        {
            public AdherentCheckTestCases()
            {
                // not fount
                Add(null, CheckAdherentEnum.NOT_FOUND, []);

                // En regle
                Add(new Adherent
                {
                    IdAdherent = "ADH001",
                    Categorie = new Categorie { NombreDocument = 2, DureePret = 14 },
                    EtatAdherent = 1,
                    PenaliteAdherents = [],
                    Prets = [],
                    Reservations = [],
                    HistoriquePrets = [],
                    HistoriquePenaliteAdherents = []
                }, CheckAdherentEnum.AUTHORIZED, []);
                // Suspendu 
                Add(new Adherent
                {
                    IdAdherent = "ADH001",
                    EtatAdherent = 3,
                    Categorie = null,
                    PenaliteAdherents = [],
                    Prets = [],
                    Reservations = [],
                    HistoriquePrets = [],
                    HistoriquePenaliteAdherents = []
                }, CheckAdherentEnum.SUSPENDED, []);
                // Penalise
                Add(new Adherent
                {
                    IdAdherent = "ADH003",
                    EtatAdherent = 2,
                    PenaliteAdherents = [],
                    Prets = [],
                    Reservations = [],
                    HistoriquePrets = [],
                    HistoriquePenaliteAdherents = []
                },
                CheckAdherentEnum.PENALISED, []);
                // En regle pas de categorie
                Add(new Adherent
                {
                    IdAdherent = "ADH004",
                    EtatAdherent = 1,
                    Categorie = null,
                    PenaliteAdherents = [],
                    Prets = [],
                    Reservations = [],
                    HistoriquePrets = [],
                    HistoriquePenaliteAdherents = []
                },
                CheckAdherentEnum.NOT_FOUND, []);
                // En regle quota reached 
                Add(new Adherent
                {
                    IdAdherent = "ADH005",
                    EtatAdherent = 1,
                    Categorie = new Categorie { NombreDocument = 2, DureePret = 14 },
                    PenaliteAdherents = [],
                    Prets = [new Pret(), new Pret()], // == NombreDocument
                    Reservations = [],
                    HistoriquePrets = [],
                    HistoriquePenaliteAdherents = []
                },
                CheckAdherentEnum.QUOTA_REACHED, []);
            }

        }
        [Theory]
        [ClassData(typeof(AdherentCheckTestCases))]
        public async Task CheckAdherentPourPret_ReturnsExpectedState(
        Adherent? adherent,
        CheckAdherentEnum expectedEtat,
        List<JoursFery> joursFeries)
        {
            // Arrange
            var list = adherent is null
                ? []
                : new List<Adherent> { adherent };

            var mockQueryable = new TestAsyncQueryable<Adherent>(list);

            _adherentRepositoryMock
                .Setup(r => r.GetQueryable(
                    It.IsAny<Expression<Func<Adherent, object>>>(),
                    It.IsAny<Expression<Func<Adherent, object>>>(),
                    It.IsAny<Expression<Func<Adherent, object>>>(),
                    It.IsAny<Expression<Func<Adherent, object>>>(),
                    It.IsAny<Expression<Func<Adherent, object>>>(),
                    It.IsAny<Expression<Func<Adherent, object>>>(),
                    It.IsAny<Expression<Func<Adherent, object>>>()
                ))
                .Returns(mockQueryable);
            var joursFeriesQueryable = new TestAsyncQueryable<JoursFery>(joursFeries);
            _joursFeriesRepositoryMock
                .Setup(r => r.GetQueryable())
                .Returns(joursFeriesQueryable);
            // Act
            var result = await _sut.CheckAdherentPourPret(adherent?.IdAdherent ?? "UNKNOWN");

            // Assert
            Assert.Equal(expectedEtat, result.Etat);
        }
    }

}



public class GetStatsTests : AdherentServiceTest
{
    /*
    └── Verify correct counts are mapped to correct DTO fields
    */
}
