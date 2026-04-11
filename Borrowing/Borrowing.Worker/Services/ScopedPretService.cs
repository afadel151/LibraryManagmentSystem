
using Borrowing.Worker.Extensions;
using Borrowing.Worker.Repositories;
using Microsoft.EntityFrameworkCore;

using LibraryManagement.Shared.Models;

namespace Borrowing.Worker.Services;
public interface IScopedPretService
{
    Task Run();
}
public sealed class ScopedPretService(
    IPretRepository pretRepository,
    IHistoriquePenaliteAdherentRepository historiquePretRepository,
    IExemplairesRepository exemplairesRepository,
    IAdherentRepository adherentRepository,
    ICategorieRepository categorieRepository,
    IPenaliteAdherentRepository penaliteAdherentRepository,
    IPenaliteRepository penaliteRepository,
    IJoursFeriesRepository joursFeriesRepository,
    IReservationRepository reservationRepository,
    ILogger<ScopedPretService> logger
    ) : IScopedPretService
{
    private readonly IPretRepository _pretRepository = pretRepository;
    private readonly IJoursFeriesRepository _joursFeriesRepository = joursFeriesRepository;
    private readonly IPenaliteAdherentRepository _penaliteAdherentRepository = penaliteAdherentRepository;
    private readonly IPenaliteRepository _penaliteRepository = penaliteRepository;
    private readonly IHistoriquePenaliteAdherentRepository _historiquePretRepository = historiquePretRepository;
    private readonly IExemplairesRepository _exemplairesRepository = exemplairesRepository;
    private readonly IAdherentRepository _adherentRepository = adherentRepository;
    private readonly IReservationRepository _reservationRepository = reservationRepository;
    private readonly ICategorieRepository _categorieRepository = categorieRepository;
    private readonly ILogger<ScopedPretService> _logger = logger;
    public async Task Run()
    {
        var prets = await _pretRepository.GetQueryable()
                                    .Include(p => p.Adherent)
                                        .ThenInclude(a => a.Categorie)
                                    .Include(p => p.Adherent)
                                        .ThenInclude(a => a.PenaliteAdherents)
                                    .Include(p => p.Exemplaire)
                                    .ToListAsync();
        var joursFeries = await _joursFeriesRepository.GetQueryable().ToListAsync();

        foreach (var pret in prets)
        {
            var adherent = pret.Adherent;
            int dureePret = (int)pret.Adherent.Categorie?.DureePret!;
            var dateRetourPrevu = pret.DatePret.AddDays(dureePret);

            dateRetourPrevu = BaseExtensions.Traiter_date(dateRetourPrevu, joursFeries);
            if (DateTime.Now.Date > dateRetourPrevu) // retard
            {
                if (pret.IdAdherent == "99/999")
                {
                    await HandleReservation(pret,prets);
                }
                if (adherent.PenaliteAdherents.Count > 0)
                {
                    try
                    {
                        adherent.EtatAdherent = 2;
                        await _adherentRepository.UpdateAsync(adherent);
                         _logger.LogInformation("Adherent penalise ....");

                    }
                    catch
                    {
                        _logger.LogError("Erreur lors de mise a jours d'un adherent en etat Bloque");
                    }
                }
                else
                {
                    try
                    {
                        var penalite = new PenaliteAdherent
                        {
                            IdAdherent = adherent.IdAdherent,
                            DatePenalite = dateRetourPrevu,
                            NombreJoursPenalite = 0
                        };
                        await _penaliteAdherentRepository.AddAsync(penalite);
                        adherent.EtatAdherent = 2;
                        await _adherentRepository.UpdateAsync(adherent);
                         _logger.LogInformation("Adherent penalise ....");
                    }
                    catch
                    {
                        _logger.LogError("Erreur lors de penalisation de l'adherent");
                    }
                }
            }

        }
    }

    public async Task HandleReservation(Pret pret,List<Pret> prets)
    {
        bool mail_connected = false;
        int bloquedCopiesCount = prets.Count(p => p.IdExemplaire.StartsWith(pret.Exemplaire.Cote + "/") && p.IdAdherent == "99/999");
        int reservationsCount = await _reservationRepository.GetQueryable()
                                        .CountAsync(r => r.Cote == pret.Exemplaire.Cote);
        if (bloquedCopiesCount == reservationsCount)
        {
            _logger.LogInformation("Adherent penalise ....");

        }
        else
        {
            var firstReservation = await _reservationRepository.GetQueryable()
                                        .OrderBy(r => r.HeureReservation)
                                        .FirstOrDefaultAsync(); 
            if (mail_connected)
            {
                // send email
                _logger.LogInformation("SENDING EMAL ....");
            }
            else
            {
                _logger.LogInformation("MAIL SERVER NOT CONNECTED ....");
                
            }
            

        }

    }


}