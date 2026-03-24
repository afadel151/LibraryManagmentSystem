using Borrowing.Api.Repositories;
using Shared.Models;
using Microsoft.EntityFrameworkCore;
namespace Borrowing.Api.Services;

public interface IAdherentService
{
    Task<Adherent?> GetAdherentWithDetailsAsync(string adherentId);
    Task<Categorie?> GetAdherentCategorie(string adherentId);
    Task<DateTime> CalculateExpectedReturnDate(DateTime startDate, decimal duration);
}

public class AdherentService(
    IAdherentRepository adherentRepository,
    IEtatAdherentRepository etatAdherentRepository,
    ICategorieRepository categorieRepository,
    IJoursFeriesRepository joursFeriesRepository
) : IAdherentService
{
    private readonly IAdherentRepository _adherentRepository = adherentRepository;
    private readonly IEtatAdherentRepository _etatAdherentRepository = etatAdherentRepository;
    private readonly ICategorieRepository _categorieRepository = categorieRepository;
    private readonly IJoursFeriesRepository _joursFeriesRepository = joursFeriesRepository;

    public async Task<Adherent?> GetAdherentWithDetailsAsync(string adherentId)
    {
        var adherent = await _adherentRepository.GetQueryable(a => a.Categorie!).FirstOrDefaultAsync(a => a.IdAdherent == adherentId);

        if (adherent != null)
        {
            return adherent;
        }
        return null;
    }

    public async Task<Categorie?> GetAdherentCategorie(string adherentId)
    {
        return await _adherentRepository
            .GetQueryable()
            .Where(a => a.IdAdherent == adherentId)
            .Join(
                _categorieRepository.GetQueryable(),
                    a => a.IdCategorie,
                c => c.IdCategorie,
                (a, c) => c
            )
            .FirstOrDefaultAsync();
    }
    public async Task<DateTime> CalculateExpectedReturnDate(DateTime startDate, decimal duration)
    {
        DateTime rawReturnDate = startDate.AddDays((double)duration);
        return await Traiter_date(rawReturnDate);
    }

    private async Task<DateTime> Traiter_date(DateTime date)
    {
        bool changement = false;
        // si vendredi ou samedi
        DayOfWeek day = date.DayOfWeek;
        if (day == DayOfWeek.Friday || day == DayOfWeek.Saturday)
        {
            date = date.AddDays(1);
            changement = true;
        }
        else // sinon verif si c'est un jours feriees
        {
            IEnumerable<JoursFery> joursFeries = await _joursFeriesRepository.GetAllAsync();
            bool isHoliday = joursFeries.Any(j => j.DateJourFerie.Date == date.Date);
            if (isHoliday)
            {
                date = date.AddDays(1);
                changement = true;
            }
        }
        // recursivite sur nouvelle date s'il ya un changement
        if (changement)
        {
            return await Traiter_date(date);
        }
        // pas de changement
        return date;
    }
}