
using Borrowing.ScheduledTask.Extensions;
using Borrowing.ScheduledTask.Repositories;
using Borrowing.ScheduledTask.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Common.Models;

namespace Borrowing.ScheduledTask.Services;

internal interface IScopedPretService
{
    Task Run();
}
internal sealed class ScopedPretService(
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
                // en retard
                if (pret.IdAdherent == "99/999")
                {
                    await HandleReservation(pret, prets);
                }
                else //---------- Traiter le cas des p�nalit�s pour les autres utilisateurs autres que les reservateurs
                {
                    if (adherent.PenaliteAdherents.Count > 0)
                    {
                        try
                        {
                            adherent.EtatAdherent = 2;
                            await _adherentRepository.UpdateAsync(adherent).ConfigureAwait(false);
                            _logger.LogInformation("Adherent penalise ....");

                        }
                        catch (Exception ex)
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
                        catch (Exception ex)
                        {
                            _logger.LogError("Erreur lors de penalisation de l'adherent");
                        }
                    }

                }
                //---- fin de test sur (retard)
            }

        }//------ fin de while (not requete_timer.eof)
    }

    public async Task HandleReservation(Pret pret, List<Pret> prets) // done
    {
        bool mail_connected = false;
        int bloquedCopiesCount = prets.Count(p => p.IdExemplaire.StartsWith(pret.Exemplaire.Cote + "/", StringComparison.OrdinalIgnoreCase) && p.IdAdherent == "99/999");//N1
        var coteReservations = await _reservationRepository.GetQueryable()
                                        .Where(r => r.Cote == pret.Exemplaire.Cote)
                                        .OrderBy(r => r.HeureReservation)
                                        .ToListAsync();
        var firstreservator = coteReservations.First();
        if (bloquedCopiesCount == coteReservations.Count) // N1==N2
        {
            _logger.LogInformation("N1=N2 ....");
            //----- Supprimer ( 99/999, ????= id_exemplaire ) de la table pret
            try { await _pretRepository.DeleteAsync(pret); }
            catch (Exception ex)
            {
                _logger.LogError("Error deleting Pret 1");
            }
            //---------- selectionner le premier qui a reserv�
            try { await _reservationRepository.DeleteAsync(firstreservator); }
            catch (Exception ex)
            {
                _logger.LogError("Error deleting Reservation 2");
            }
            var exemplaire = pret.Exemplaire;
            exemplaire.IdEtat = 1;
            try
            {
                await _exemplairesRepository.UpdateAsync(exemplaire);
            }
            catch (Exception ex)
            {
                _logger.LogError("error editing exemplaire 3");
            }
        }
        else
        {
            //---------- selectionner le premier qui a reserv�
            try { await _reservationRepository.DeleteAsync(firstreservator); }
            catch (Exception ex)
            {
                _logger.LogError("Error deleting Reservation 4");
            }
            //------------------ Lancer les relances
            if (mail_connected)
            {
                // send email
                _logger.LogInformation("SENDING EMAL ....");
            }
            else
            {
                _logger.LogInformation("MAIL SERVER NOT CONNECTED ....");
            }
            //------------------ Changer la date dans la table pret
            pret.DatePret = DateTime.Now.Date;
            try
            { await _pretRepository.UpdateAsync(pret); }
            catch (Exception ex)
            {
                _logger.LogError("Error updating pret 5");
            }
        }
    }
}