using Borrowing.SharedClasses.Common;
using Borrowing.SharedClasses.Requests.Pret;
using Borrowing.SharedClasses.Responses.Pret;
using Borrowing.Api.Repositories;
using Shared.Models;
using Microsoft.EntityFrameworkCore;
using Borrowing.Api.Extensions;

namespace Borrowing.Api.Services;

public interface IPretService
{
    Task<Pret?> CreatePretAsync(CreatePretRequestDto pretRequestDTo);
    Task<int> CountAsync();
    Task<PagedResult<PretResponseDto>> GetPretsAsync(PaginatedQueryParameters queryParameters);
    Task<bool> RestitutionPret(string IdAdherent, string IdExemplaire);
    Task<bool> RenouvlementPret(string IdAdherent, string IdExemplaire);
    Task<int> CountAdherentActiveLoans(string AdherentId);
    // Task<bool> DeletePret(string IdAdherent, string IdExemplaire);
    Task<List<Pret>> GetBlockedCopies(string cote);
    Task<Pret?> GetPretByExemplaireId(string IdExemplaire);

}

public class PretService(
    IPretRepository pretRepository,
    IHistoriquePretRepository historiquePretRepository,
    IExemplairesRepository exemplairesRepository,
    IAdherentRepository adherentRepository,
    IPositionRepository positionRepository,
    ICategorieRepository categorieRepository,
    IPenaliteAdherentRepository penaliteAdherentRepository,
    IPenaliteRepository penaliteRepository,
    IJoursFeriesRepository joursFeriesRepository,
    IReservationRepository reservationRepository,
    INoticesRepository noticesRepository) : IPretService
{
    private readonly IPretRepository _pretRepository = pretRepository;
    private readonly IJoursFeriesRepository _joursFeriesRepository = joursFeriesRepository;
    private readonly IPenaliteAdherentRepository _penaliteAdherentRepository = penaliteAdherentRepository;
    private readonly IPenaliteRepository _penaliteRepository = penaliteRepository;
    private readonly IHistoriquePretRepository _historiquePretRepository = historiquePretRepository;
    private readonly IExemplairesRepository _exemplairesRepository = exemplairesRepository;
    private readonly IAdherentRepository _adherentRepository = adherentRepository;
    private readonly IPositionRepository _positionRepository = positionRepository;
    private readonly IReservationRepository _reservationRepository = reservationRepository;
    private readonly ICategorieRepository _categorieRepository = categorieRepository;
    private readonly INoticesRepository _noticesRepository = noticesRepository;

    public async Task<Pret?> CreatePretAsync(CreatePretRequestDto pretRequestDTo)
    {
        var pret = new Pret
        {
            IdAdherent = pretRequestDTo.AdherentId,
            IdExemplaire = pretRequestDTo.ExemplaireId,
            DatePret = DateTime.Now.Date
        };
        try
        {
            await _pretRepository.AddAsync(pret);
            return pret;
        }
        catch (System.Exception)
        {
            return null;
        }
    }

    public async Task<PagedResult<PretResponseDto>> GetPretsAsync(PaginatedQueryParameters queryParameters)
    {

        var prets = _pretRepository.GetQueryable();
        var adherents = _adherentRepository.GetQueryable();
        var positions = _positionRepository.GetQueryable();
        var categories = _categorieRepository.GetQueryable();
        var exemplaires = _exemplairesRepository.GetQueryable();
        var notices = _noticesRepository.GetQueryable();

        var query = from p in prets
                    join a in adherents on p.IdAdherent equals a.IdAdherent
                    join pos in positions on a.IdPosition equals pos.IdPosition into posGrp
                    from pos in posGrp.DefaultIfEmpty()
                    join c in categories on a.IdCategorie equals c.IdCategorie into catGrp
                    from c in catGrp.DefaultIfEmpty()
                    join e in exemplaires on p.IdExemplaire equals e.IdExemplaire
                    join n in notices on e.Cote equals n.Cote into noticeGrp
                    from n in noticeGrp.DefaultIfEmpty()
                    select new PretResponseDto
                    {
                        AdherentId = a.IdAdherent ?? string.Empty,
                        AdherentNom = a.Nom ?? string.Empty,
                        AdherentPrenom = a.Prenom ?? string.Empty,
                        AdherentCategorie = c != null ? c.LibelleCategorie ?? string.Empty : string.Empty,
                        NoticeTitrePropre = n != null ? n.TitrePropre ?? string.Empty : string.Empty,
                        NoticeCote = n != null ? n.Cote ?? string.Empty : string.Empty,
                        ExemplaireId = p.IdExemplaire ?? string.Empty,
                        DatePret = p.DatePret,
                        EtatDuree = p.EtatDuree
                    };

        // Apply search
        if (!string.IsNullOrWhiteSpace(queryParameters.Search))
        {
            var search = queryParameters.Search.ToLower(); // only once, on the in-memory value
            query = query.Where(x =>
                x.AdherentId.ToLower().Contains(search) ||
                x.AdherentNom.ToLower().Contains(search) ||
                x.AdherentPrenom.ToLower().Contains(search) ||
                x.NoticeTitrePropre.ToLower().Contains(search) ||
                x.ExemplaireId.ToLower().Contains(search));
        }
        // Apply ordering
        if (!string.IsNullOrWhiteSpace(queryParameters.OrderBy))
        {
            query = queryParameters.OrderBy.ToLower() switch
            {
                "datepret asc" => query.OrderBy(x => x.DatePret),
                "datepret desc" => query.OrderByDescending(x => x.DatePret),

                "adherentid asc" => query.OrderBy(x => x.AdherentId),
                "adherentid desc" => query.OrderByDescending(x => x.AdherentId),

                "adherentnom asc" => query.OrderBy(x => x.AdherentNom),
                "adherentnom desc" => query.OrderByDescending(x => x.AdherentNom),

                "adherentprenom asc" => query.OrderBy(x => x.AdherentPrenom),
                "adherentprenom desc" => query.OrderByDescending(x => x.AdherentPrenom),

                "adherentcategorie asc" => query.OrderBy(x => x.AdherentCategorie),
                "adherentcategorie desc" => query.OrderByDescending(x => x.AdherentCategorie),

                "exemplaireid asc" => query.OrderBy(x => x.NoticeTitrePropre),
                "exemplaireid desc" => query.OrderByDescending(x => x.NoticeTitrePropre),

                "noticetitrepropre asc" => query.OrderBy(x => x.NoticeTitrePropre),
                "noticetitrepropre desc" => query.OrderByDescending(x => x.NoticeTitrePropre),

                "titre asc" => query.OrderBy(x => x.NoticeTitrePropre),
                "titre desc" => query.OrderByDescending(x => x.NoticeTitrePropre),

                "etatduree asc" => query.OrderBy(x => x.EtatDuree),
                "etatduree desc" => query.OrderByDescending(x => x.EtatDuree),
                _ => query.OrderByDescending(x => x.DatePret) // defalt 
            };
        }
        else
        {
            query = query.OrderByDescending(x => x.DatePret); // Default orderin
        }

        var totalCount = await query.CountAsync();

        var data = await query
            .Skip((queryParameters.PageNumber - 1) * queryParameters.PageSize)
            .Take(queryParameters.PageSize)
            .ToListAsync();

        return new PagedResult<PretResponseDto>
        {
            Data = data,
            TotalCount = totalCount,
            PageNumber = queryParameters.PageNumber,
            PageSize = queryParameters.PageSize
        };
    }

    public async Task<int> CountAdherentActiveLoans(string adherentId)
    {
        return await _pretRepository.GetQueryable()
                    .Where(
                        p => p.IdAdherent == adherentId
                    )
                    .CountAsync();
    }
    public async Task<int> CountAsync()
    {
        return await _pretRepository.GetQueryable().CountAsync();
    }

    public async Task<List<Pret>> GetBlockedCopies(string cote)
    {
        return await _pretRepository.GetQueryable()
            .Where(p => EF.Functions.Like(
                p.IdExemplaire.ToUpper(),
                cote.ToUpper() + "/%"))
            .Where(p => p.IdAdherent == "99/999")
            .OrderBy(p => p.DatePret)
            .ToListAsync();
    }

    public async Task<Pret?> GetPretByExemplaireId(string IdExemplaire)
    {
        return await _pretRepository.GetQueryable()
            .Where(p => p.IdExemplaire == IdExemplaire)
            .FirstOrDefaultAsync();
    }



   public async Task<bool> RestitutionPret(string IdAdherent, string IdExemplaire)
        {
            ArgumentNullException.ThrowIfNull(IdAdherent);
            ArgumentNullException.ThrowIfNull(IdExemplaire);

            DateTime dateRetour =  DateTime.Now.Date;

            var prets = await _pretRepository.FindAsync(p => p.IdAdherent == IdAdherent && p.IdExemplaire == IdExemplaire);
            //cherchcer pret
            var pret = prets.FirstOrDefault();

            if (pret == null) return false;

            try
            {
                // rechercher exemplaire
                var exemplaire = await _exemplairesRepository.GetQueryable().Where(e => e.IdExemplaire == pret.IdExemplaire).FirstOrDefaultAsync();
                if (exemplaire == null) return false;

                // Extraction de la cote
                string cote = exemplaire.Cote!;
                if (string.IsNullOrEmpty(cote) && IdExemplaire.Contains('/'))
                {
                    cote = IdExemplaire.Substring(0, IdExemplaire.LastIndexOf('/'));
                }
                cote ??= IdExemplaire;

                //  Sauvegarder dans historique_pret
                var historique = new HistoriquePret
                {
                    IdAdherent = IdAdherent,
                    IdExemplaire = IdExemplaire,
                    DatePret = pret.DatePret,
                    DateRetour = dateRetour
                };
                await _historiquePretRepository.AddAsync(historique);

                //  Calcul du retard
                bool retard = false;
                int nbrJoursRetardDocEnCours = 0;
                // get adherent
                var adherent = await _adherentRepository.GetQueryable(a=>a.Categorie!,a => a.PenaliteAdherents,a=>a.Prets).Where(a => a.IdAdherent == IdAdherent).FirstOrDefaultAsync();

                if (adherent != null && adherent.IdCategorie != null)
                {

                    var categorie = adherent.Categorie;
                    
                    if (categorie != null && categorie.DureePret.HasValue)
                    {
                        int dureePret = (int)categorie.DureePret;
                        DateTime dateRestitutionPrevue = pret.DatePret.AddDays(dureePret);

                        // calculer date restitution prevue
                        var joursFeries = await _joursFeriesRepository.GetAllAsync();
                        dateRestitutionPrevue = BaseExtensions.Traiter_date(dateRestitutionPrevue, joursFeries.ToList());

                        // Vérifier si durée ouverte
                        if (pret.EtatDuree?.ToUpper() != "O")
                        {
                            // date aujourdhui > date rest prevue
                            if (DateTime.Now.Date > dateRestitutionPrevue)
                            {
                                retard = true; // il est en retard
                                nbrJoursRetardDocEnCours = (DateTime.Now.Date - dateRestitutionPrevue).Days;
                                Console.WriteLine("##### 1");

                                // Extraire le nombre de jours de pénalité depuis la table penalite
                                var penaliteRecord = await _penaliteRepository.GetQueryable()
                                    .Where(p => p.IdCategorie == adherent.IdCategorie && p.JoursRetard <= nbrJoursRetardDocEnCours)
                                    .OrderBy(p => p.NombreJoursRetard)
                                    .LastOrDefaultAsync();

                                if (penaliteRecord != null)
                                {
                                    Console.WriteLine("##### 2");
                                    nbrJoursRetardDocEnCours = (int)penaliteRecord.NombreJoursRetard!;
                                }
                            }
                        }
                    }
                }

                // 3. Vérification existence dans penalite_adherent
                Console.WriteLine("##### 3");

                bool existeDansPenaliteAdherent = false;
                int nbrJoursRetardDansTablePenaliteAdherent = 0;
                var penaliteAdherentExistante = adherent!.PenaliteAdherents.FirstOrDefault();
                Console.WriteLine("##### 4");

                if (penaliteAdherentExistante != null)
                {
                    existeDansPenaliteAdherent = true;
                    nbrJoursRetardDansTablePenaliteAdherent = Math.Abs((int)(penaliteAdherentExistante.NombreJoursPenalite ?? 0));
                }

                // prets en cours
                int nbrPretUtilisateurEnCours = adherent.Prets.Count;
                Console.WriteLine("##### 5");

                // gestion des pénalités
                if (retard)
                {
                    Console.WriteLine("##### 6");

                    int joursRetardFinal = 0;

                    if (nbrPretUtilisateurEnCours == 1) // Dernier document
                    {
                        if (existeDansPenaliteAdherent)
                        {
                            joursRetardFinal = Math.Max(nbrJoursRetardDocEnCours, nbrJoursRetardDansTablePenaliteAdherent);
                            penaliteAdherentExistante!.DatePenalite = DateTime.Now.Date;
                            penaliteAdherentExistante.NombreJoursPenalite = joursRetardFinal;
                            await _penaliteAdherentRepository.UpdateAsync(penaliteAdherentExistante);
                        }
                        else
                        {
                            joursRetardFinal = nbrJoursRetardDocEnCours;
                            await _penaliteAdherentRepository.AddAsync(new PenaliteAdherent
                            {
                                IdAdherent = IdAdherent,
                                DatePenalite = DateTime.Now.Date,
                                NombreJoursPenalite = joursRetardFinal
                            });
                        }
                    }
                    else // Il a d'autres documents en possession
                    {
                        if (existeDansPenaliteAdherent)
                        {
                            joursRetardFinal = Math.Max(nbrJoursRetardDocEnCours, nbrJoursRetardDansTablePenaliteAdherent) * -1; // Négatif
                            penaliteAdherentExistante!.DatePenalite = DateTime.Now.Date;
                            penaliteAdherentExistante.NombreJoursPenalite = joursRetardFinal;
                            await _penaliteAdherentRepository.UpdateAsync(penaliteAdherentExistante);
                        }
                        else
                        {
                            joursRetardFinal = nbrJoursRetardDocEnCours * -1; // Négatif
                            await _penaliteAdherentRepository.AddAsync(new PenaliteAdherent
                            {
                                IdAdherent = IdAdherent,
                                DatePenalite = DateTime.Now.Date,
                                NombreJoursPenalite = joursRetardFinal
                            });
                        }
                    }

                    // Pénaliser l'adhérent (Etat 2)
                    if (adherent != null)
                    {
                        adherent.EtatAdherent = 2;
                        await _adherentRepository.UpdateAsync(adherent);
                    }
                }
                else 
                {
                    if (nbrPretUtilisateurEnCours == 1)
                    {
                        if (existeDansPenaliteAdherent)
                        {
                            penaliteAdherentExistante!.DatePenalite = DateTime.Now.Date;
                            penaliteAdherentExistante.NombreJoursPenalite = nbrJoursRetardDansTablePenaliteAdherent;
                            await _penaliteAdherentRepository.UpdateAsync(penaliteAdherentExistante);
                        }
                    }
                }

                // 6. Traitement des réservations
                int nbrReservations = await _reservationRepository.GetQueryable()
                    .CountAsync(r => r.Cote == cote);

                int nbrPretReservations = await _pretRepository.GetQueryable()
                    .CountAsync(p => p.IdAdherent == "99/999" && p.IdExemplaire.StartsWith(cote + "/"));

                if (nbrReservations > 0 && nbrPretReservations < nbrReservations)
                {
                    // Création du prêt fictif de réservation
                    var pretFictif = new Pret
                    {
                        IdAdherent = "99/999",
                        IdExemplaire = IdExemplaire,
                        DatePret = dateRetour,
                        EtatDuree = "F"
                    };
                    await _pretRepository.AddAsync(pretFictif);

                    exemplaire.IdEtat = 2; // État Réservé
                    await _exemplairesRepository.UpdateAsync(exemplaire);
                }
                else
                {
                    exemplaire.IdEtat = 1; // disponible
                    await _exemplairesRepository.UpdateAsync(exemplaire);
                }

                // 7. Suppression définitive du prêt
                await _pretRepository.DeleteAsync(pret);

                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return false;
            }
        }

    public async Task<bool>  RenouvlementPret(string IdAdherent, string IdExemplaire)
    {
        var result = await RestitutionPret(IdAdherent,IdExemplaire);
        if (result)
        {
            var exemplaire = await _exemplairesRepository.GetQueryable().Where(e => e.IdExemplaire == IdExemplaire).FirstOrDefaultAsync();
            var adherent = await _adherentRepository.GetQueryable().Where(a => a.IdAdherent == IdAdherent).FirstOrDefaultAsync();
            if (exemplaire == null || adherent == null) return false;

            if (exemplaire.IdEtat == 1)
            {
                if (adherent.EtatAdherent == 1)
                {
                    var pret = await CreatePretAsync(new CreatePretRequestDto{AdherentId = IdAdherent,ExemplaireId = IdExemplaire});
                    if (pret == null)
                    {
                        return false;
                    }
                    else
                    {
                        return true;
                    } // pret non cree
                }
                Console.WriteLine("adherent penalise");
                return false; // adherent penalise
            }
            Console.WriteLine("exemplaire no longer available");
            return false; // exemplaire no longer available
        }
        Console.WriteLine("Erreur de restitution");

        return false;// erreur de restitution
    }
    
}