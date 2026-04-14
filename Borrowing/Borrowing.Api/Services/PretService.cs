using Borrowing.SharedClasses.Models;
using Borrowing.SharedClasses.Requests.Pret;
using Borrowing.SharedClasses.Responses.Pret;
using Borrowing.Api.Repositories;
using Common.Models;
using Microsoft.EntityFrameworkCore;
using Borrowing.Api.Extensions;

namespace Borrowing.Api.Services;

public interface IPretService
{
    Task<bool> CreatePretAsync(CreatePretRequestDto pretRequestDTo);
    Task<int> CountAsync();
    Task<PagedResult<PretResponseDto>> GetPretsAsync(PaginatedQueryParameters queryParameters);
    Task<ApiResult> RestitutionPret(string IdAdherent, string IdExemplaire);
    Task<bool> RenouvlementPret(string IdAdherent, string IdExemplaire);
    Task<int> CountAdherentActiveLoans(string AdherentId);
    Task<bool> DeletePret(string IdAdherent, string IdExemplaire);
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

    public async Task<bool> CreatePretAsync(CreatePretRequestDto pretRequestDTo)
    {
        ArgumentNullException.ThrowIfNull(pretRequestDTo);
        var pret = new Pret
        {
            IdAdherent = pretRequestDTo.AdherentId,
            IdExemplaire = pretRequestDTo.ExemplaireId,
            DatePret = DateTime.Now.Date
        };
        try
        {
            await _pretRepository.AddAsync(pret);
            return true;
        }
        catch (Exception ex)
        {

            return false;
        }
    }
    public async Task<bool> DeletePret(string IdAdherent, string IdExemplaire)
    {
        ArgumentNullException.ThrowIfNull(IdAdherent);
        ArgumentNullException.ThrowIfNull(IdExemplaire);
        var pret = await _pretRepository.GetQueryable()
                .Where(p => p.IdAdherent == IdAdherent && p.IdExemplaire == IdExemplaire)
                .FirstOrDefaultAsync();
        if (pret == null) return false;

        try
        {
            await _pretRepository.DeleteAsync(pret);
            return true;
        }
        catch (System.Exception)
        {
            return false;
        }
    }
    public async Task<PagedResult<PretResponseDto>> GetPretsAsync(PaginatedQueryParameters queryParameters)
    {
        ArgumentNullException.ThrowIfNull(queryParameters);

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
            var search = queryParameters.Search.ToUpper(); // only once, on the in-memory value
            query = query.Where(x =>
                x.AdherentId.ToUpper().Contains(search, StringComparison.InvariantCulture) ||
                x.AdherentNom.ToUpper().Contains(search, StringComparison.InvariantCulture) ||
                x.AdherentPrenom.ToUpper().Contains(search, StringComparison.InvariantCulture) ||
                x.NoticeTitrePropre.ToUpper().Contains(search, StringComparison.InvariantCulture) ||
                x.ExemplaireId.ToUpper().Contains(search, StringComparison.InvariantCulture));
        }
        // Apply ordering
        if (!string.IsNullOrWhiteSpace(queryParameters.OrderBy))
        {
            query = queryParameters.OrderBy.ToUpper() switch
            {
                "datepret ASC" => query.OrderBy(x => x.DatePret),
                "datepret DESC" => query.OrderByDescending(x => x.DatePret),

                "ADHERENTID ASC" => query.OrderBy(x => x.AdherentId),
                "ADHERENTID DESC" => query.OrderByDescending(x => x.AdherentId),

                "ADHERENTNOM ASC" => query.OrderBy(x => x.AdherentNom),
                "ADHERENTNOM DESC" => query.OrderByDescending(x => x.AdherentNom),

                "ADHERENTPRENOM ASC" => query.OrderBy(x => x.AdherentPrenom),
                "ADHERENTPRENOM DESC" => query.OrderByDescending(x => x.AdherentPrenom),

                "ADHERENTCATEGORIE ASC" => query.OrderBy(x => x.AdherentCategorie),
                "ADHERENTCATEGORIE DESC" => query.OrderByDescending(x => x.AdherentCategorie),

                "EXEMPLAIREID ASC" => query.OrderBy(x => x.ExemplaireId),
                "EXEMPLAIREID DESC" => query.OrderByDescending(x => x.ExemplaireId),

                "NOTICETITREPROPRE ASC" => query.OrderBy(x => x.NoticeTitrePropre),
                "NOTICETITREPROPRE DESC" => query.OrderByDescending(x => x.NoticeTitrePropre),

                "TITRE ASC" => query.OrderBy(x => x.NoticeTitrePropre),
                "TITRE DESC" => query.OrderByDescending(x => x.NoticeTitrePropre),

                "ETATDUREE ASC" => query.OrderBy(x => x.EtatDuree),
                "ETATDUREE DESC" => query.OrderByDescending(x => x.EtatDuree),
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

    public async Task<int> CountAdherentActiveLoans(string AdherentId)
    {
        ArgumentNullException.ThrowIfNull(AdherentId);
        return await _pretRepository.GetQueryable()
                    .Where(
                        p => p.IdAdherent == AdherentId
                    )
                    .CountAsync();
    }
    public async Task<int> CountAsync()
    {
        return await _pretRepository.GetQueryable().CountAsync();
    }

    public async Task<List<Pret>> GetBlockedCopies(string cote)
    {
        ArgumentNullException.ThrowIfNull(cote);
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
        ArgumentNullException.ThrowIfNull(IdExemplaire);
        return await _pretRepository.GetQueryable()
            .Where(p => p.IdExemplaire == IdExemplaire)
            .FirstOrDefaultAsync();
    }



    public async Task<ApiResult> RestitutionPret(string IdAdherent, string IdExemplaire)
    {
        ArgumentNullException.ThrowIfNull(IdAdherent);
        ArgumentNullException.ThrowIfNull(IdExemplaire);

        DateTime dateRetour = DateTime.Now.Date;

        var prets = await _pretRepository.FindAsync(p => p.IdAdherent == IdAdherent && p.IdExemplaire == IdExemplaire);
        //cherchcer pret
        var pret = prets.FirstOrDefault();

        if (pret == null) return ApiResult.Fail("Prêt introuvable.", "PRET_NOT_FOUND"); 


        // rechercher exemplaire
        var exemplaire = await _exemplairesRepository.GetQueryable().Where(e => e.IdExemplaire == pret.IdExemplaire).FirstOrDefaultAsync();
        if (exemplaire == null) return ApiResult.Fail("Exemplaire introuvable.", "EXEMPLAIRE_NOT_FOUND"); ;

        // Extraction de la cote
        string cote = exemplaire.Cote!;
        if (string.IsNullOrEmpty(cote) && IdExemplaire.Contains('/'))
        {
            cote = IdExemplaire.Substring(0, IdExemplaire.LastIndexOf('/'));
        }
        cote ??= IdExemplaire;
        Console.WriteLine("######## COTE : " + cote);
        //  Sauvegarder dans historique_pret
        var historique = new HistoriquePret
        {
            IdAdherent = IdAdherent,
            IdExemplaire = IdExemplaire,
            DatePret = pret.DatePret,
            DateRetour = dateRetour
        };
        try
        {
            await _historiquePretRepository.AddAsync(historique);

        }
        catch (Exception)
        {
            return ApiResult.Fail("Erreur lors d'ajout d'historique ");
        }
        //  Calcul du retard
        bool retard = false;
        int nbrJoursRetardDocEnCours = 0;
        // get adherent
        var adherent = await _adherentRepository.GetQueryable(a => a.Categorie!, a => a.PenaliteAdherents, a => a.Prets).Where(a => a.IdAdherent == IdAdherent).FirstOrDefaultAsync();

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

                        // Extraire le nombre de jours de pénalité depuis la table penalite
                        var penaliteRecord = await _penaliteRepository.GetQueryable()
                            .Where(p => p.IdCategorie == adherent.IdCategorie && p.JoursRetard <= nbrJoursRetardDocEnCours)
                            .OrderBy(p => p.NombreJoursRetard)
                            .LastOrDefaultAsync();

                        if (penaliteRecord != null)
                        {
                            nbrJoursRetardDocEnCours = (int)penaliteRecord.NombreJoursRetard!;
                        }
                    }
                }
            }
        }

        // 3. Vérification existence dans penalite_adherent

        bool existeDansPenaliteAdherent = false;
        int nbrJoursRetardDansTablePenaliteAdherent = 0;
        var penaliteAdherentExistante = adherent!.PenaliteAdherents.FirstOrDefault();

        if (penaliteAdherentExistante != null)
        {
            existeDansPenaliteAdherent = true;
            nbrJoursRetardDansTablePenaliteAdherent = Math.Abs((int)(penaliteAdherentExistante.NombreJoursPenalite ?? 0));
        }

        // prets en cours
        int nbrPretUtilisateurEnCours = adherent.Prets.Count;

        // gestion des pénalités
        if (retard)
        {

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
                    try
                    {
                        await _penaliteAdherentRepository.AddAsync(new PenaliteAdherent
                        {
                            IdAdherent = IdAdherent,
                            DatePenalite = DateTime.Now.Date,
                            NombreJoursPenalite = joursRetardFinal
                        });

                    }
                    catch (Exception)
                    {

                        return ApiResult.Fail("Erreur lors de la penalisation de l'adherent ");
                    }
                }
            }
            else // Il a d'autres documents en possession
            {
                if (existeDansPenaliteAdherent)
                {
                    joursRetardFinal = Math.Max(nbrJoursRetardDocEnCours, nbrJoursRetardDansTablePenaliteAdherent) * -1; // Négatif
                    penaliteAdherentExistante!.DatePenalite = DateTime.Now.Date;
                    penaliteAdherentExistante.NombreJoursPenalite = joursRetardFinal;
                    try
                    {
                        await _penaliteAdherentRepository.UpdateAsync(penaliteAdherentExistante);

                    }
                    catch (Exception)
                    {
                        return ApiResult.Fail("Erreur de penalisation s'il existe d'autre documents ");
                    }
                }
                else
                {
                    joursRetardFinal = nbrJoursRetardDocEnCours * -1; // Négatif
                    try
                    {
                        await _penaliteAdherentRepository.AddAsync(new PenaliteAdherent
                        {
                            IdAdherent = IdAdherent,
                            DatePenalite = DateTime.Now.Date,
                            NombreJoursPenalite = joursRetardFinal
                        });

                    }
                    catch (Exception)
                    {

                        return ApiResult.Fail("Erreur lors de penalisation lors du dernier document ");

                    }
                }
            }

            // Pénaliser l'adhérent (Etat 2)
            if (adherent != null)
            {
                adherent.EtatAdherent = 2;
                try
                {
                    await _adherentRepository.UpdateAsync(adherent);

                }
                catch (Exception)
                {
                    return ApiResult.Fail("Erreur lors de la mise a jours d'etat d'adherent ");
                }
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
                    try
                    {

                        await _penaliteAdherentRepository.UpdateAsync(penaliteAdherentExistante);
                    }
                    catch (Exception)
                    {
                        return ApiResult.Fail("Erreur lors de la mise a jours de penalite ");
                    }
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
            try
            {

                await _pretRepository.AddAsync(pretFictif);
            }
            catch (Exception)
            {
                return ApiResult.Fail("Erreur lors de bloquage de l'exemplaire ");
            }
            exemplaire.IdEtat = 2; // État Réservé
        }
        else
        {
            exemplaire.IdEtat = 1; // disponible
        }
        try
        {

            await _exemplairesRepository.UpdateAsync(exemplaire);
        }
        catch (Exception)
        {
            return ApiResult.Fail("Erreur lors de la mise a jours de l'exemplaire ");
        }
        try
        {
            await _pretRepository.DeleteAsync(pret);

        }
        catch (Exception)
        {
            return ApiResult.Fail("Erreur lors de suppression de pret ");
        }

        return ApiResult.Ok("Notice restituée avec succès.");

    }

    public async Task<bool> RenouvlementPret(string IdAdherent, string IdExemplaire)
    {
        var result = await RestitutionPret(IdAdherent, IdExemplaire);
        if (result.Success)
        {
            var exemplaire = await _exemplairesRepository.GetQueryable().Where(e => e.IdExemplaire == IdExemplaire).FirstOrDefaultAsync();
            var adherent = await _adherentRepository.GetQueryable().Where(a => a.IdAdherent == IdAdherent).FirstOrDefaultAsync();
            if (exemplaire == null || adherent == null) return false;

            if (exemplaire.IdEtat == 1)
            {
                if (adherent.EtatAdherent == 1)
                {
                    var pret = await CreatePretAsync(new CreatePretRequestDto { AdherentId = IdAdherent, ExemplaireId = IdExemplaire });
                    if (pret == false)
                    {
                        return false;
                    }
                    else
                    {
                        return true;
                    } // pret non cree
                }
                return false; // adherent penalise
            }
            return false; // exemplaire no longer available
        }

        return false;// erreur de restitution
    }

}