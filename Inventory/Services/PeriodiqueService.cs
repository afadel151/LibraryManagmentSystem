using Common.Models;
using Inventory.Models.Catalogue.Add;
using Inventory.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Inventory.Services;

public interface IPeriodiqueService
{
    Task<Notice> CreatePeriodiqueNotice(PeriodiqueViewModel model);
}

public class PeriodiqueService(
    INoticeRepository noticeRepository,
    IMentionResRepository mentionResRepository,
    IVilleRepository villeRepository,
    IEditeurRepository editeurRepository,
    IMotsCleRepository motsCleRepository
) : IPeriodiqueService
{
    private readonly INoticeRepository _noticeRepository = noticeRepository;
    private readonly IMentionResRepository _mentionResRepository = mentionResRepository;
    private readonly IVilleRepository _villeRepository = villeRepository;
    private readonly IEditeurRepository _editeurRepository = editeurRepository;
    private readonly IMotsCleRepository _motsCleRepository = motsCleRepository;



    public async Task<Notice> CreatePeriodiqueNotice(PeriodiqueViewModel model)
    {
        // Create the base Notice entity
        var newNotice = new Notice
        {
            Cdd = model.CDD,
            IdPeriodicite = model.ID_Periodicite,
            Cote = model.Cote + ";", // Add semicolon as in the original Pascal code
            NbrExemple = model.NbrExemplaires,
            TitrePropre = ReplaceSpecialChars(model.TitrePropre),
            SousTitre = ReplaceSpecialChars(model.SousTitre),
            TitreCle = ReplaceSpecialChars(model.TitreCle),
            IssnNotice = model.ISSN,
            Date1erPub = model.Date1Pub,
            NumeroVol = model.NumeroVol,
            Accessibilite = model.Accessibilite ? "1" : "0",
            Localisation = model.Localisation,
            CollationImpMaterielle = ReplaceSpecialChars(model.CollationImpMaterielle),
            CollationAutresCarMat = ReplaceSpecialChars(model.CollationAutresCarMat),
            CollationFormat = ReplaceSpecialChars(model.CollationFormat),
            Resume = ReplaceSpecialChars(model.Resume),
            NoteGenerale = ReplaceSpecialChars(model.NoteGenerale),
            IdType = 1, // 1 = Periodique type
            IsIndexed = 0,
            ExemplaireExiste = 0
        };

        // Add the notice to database
        var createdNotice = await _noticeRepository.AddAsync(newNotice);

        // Handle Auteur Principal (Main Author)
        if (!string.IsNullOrEmpty(model.NomAuteurPrincipal))
        {
            var mentionRes = await GetOrCreateMentionResponsabilite(
                model.NomAuteurPrincipal,
                model.AutrePartieAuteurPrincipal,
                model.Collectivite
            );

            createdNotice.Auteurs.Add(mentionRes);
        }

        // Handle Co-Auteurs
        if (model.CoAuteurs != null)
        {
            foreach (var coAuteur in model.CoAuteurs.Where(c => !string.IsNullOrEmpty(c.Nom)))
            {
                var mentionRes = await GetOrCreateMentionResponsabilite(
                    coAuteur.Nom,
                    coAuteur.AutrePartie,
                    0
                );
                createdNotice.CoAuteurs.Add(mentionRes);
            }
        }

        // Handle Auteurs Secondaires
        if (model.AuteursSecondaires != null)
        {
            foreach (var auteurSec in model.AuteursSecondaires.Where(a => !string.IsNullOrEmpty(a.Nom)))
            {
                var mentionRes = await GetOrCreateMentionResponsabilite(
                    auteurSec.Nom,
                    auteurSec.AutrePartie,
                    auteurSec.Collectivite
                );

                // You may need to set the function ID on a junction table
                // This depends on your AuteurSecondaire entity structure
                var auteurSecondaire = new AuteurSecondaire
                {
                    IdMentionRes = mentionRes.IdMentionRes,
                    IdFonction = auteurSec.ID_Fonction
                };
                createdNotice.AuteurSecondaires.Add(auteurSecondaire);
            }
        }

        // Handle Theme
        if (model.ID_Theme > 0)
        {
            // Add theme relationship if you have a NoticeTheme table
            // Similar to the Pascal code that inserts into NOTICE_THEME
        }

        // Handle Langues
        if (model.LanguesList != null)
        {
            foreach (var langue in model.LanguesList.Where(l => !string.IsNullOrEmpty(l.Value)))
            {
                var lang = new Langue { IdLangue = langue.Value };
                createdNotice.Langues.Add(lang);
            }
        }

        // Handle Pays
        if (model.PaysListItems != null)
        {
            foreach (var pays in model.PaysListItems.Where(p => !string.IsNullOrEmpty(p.Code)))
            {
                var pay = new Pay { IdPays = pays.Code };
                createdNotice.Pays.Add(pay);
            }
        }

        // Handle Mots Clés
        if (model.MotsCles != null)
        {
            foreach (var motCle in model.MotsCles.Where(m => !string.IsNullOrWhiteSpace(m)))
            {
                var mot = await GetOrCreateMotsCle(motCle);
                createdNotice.MotsCles.Add(mot);
            }
        }

        // Handle Adresses Bibliographiques
        if (model.AdressesBibliographiques != null)
        {
            foreach (var adresse in model.AdressesBibliographiques.Where(a => !string.IsNullOrEmpty(a.NomVille) || !string.IsNullOrEmpty(a.NomEditeur)))
            {
                var ville = await GetOrCreateVille(adresse.NomVille);
                var editeur = await GetOrCreateEditeur(adresse.NomEditeur);

                var noticeEdition = new NoticeEdition
                {
                    IdVille = ville.IdVille,
                    IdEditeur = editeur.IdEditeur,
                    DateEdition = adresse.Annee
                };
                createdNotice.NoticeEditions.Add(noticeEdition);
            }
        }

        // Handle Collection
        if (!string.IsNullOrEmpty(model.ID_Collection))
        {
            var noticeCollection = new NoticeCollection
            {
                IdCollection = decimal.Parse(model.ID_Collection),
                NumeroDansCollection = model.NumDansCollection
            };
            createdNotice.NoticeCollections.Add(noticeCollection);
        }

        // Handle Mention d'Édition
        if (!string.IsNullOrEmpty(model.MentionEdition))
        {
            var mentionEdition = new NoticeMentionEdition
            {
                MentionEdition = ReplaceSpecialChars(model.MentionEdition)
            };
            createdNotice.NoticeMentionEdition = mentionEdition;
        }

        return createdNotice;
    }

    // Helper methods
    private string ReplaceSpecialChars(string input)
    {
        if (string.IsNullOrEmpty(input)) return input;
        // Replace single quote with similar character as in Pascal code
        return input.Replace("'", "´");
    }

    private async Task<MentionResponsabilite> GetOrCreateMentionResponsabilite(string nom, string autrePartie, decimal collectivite)
    {
        // Check if exists
        var existing = await _mentionResRepository.FindFirstAsync(m =>
            m.Nom == nom &&
            (m.AutrePartie == autrePartie || (m.AutrePartie == null && autrePartie == "")));

        if (existing != null)
            return existing;

        // Create new
        var newMention = new MentionResponsabilite
        {
            Nom = ReplaceSpecialChars(nom),
            AutrePartie = ReplaceSpecialChars(autrePartie),
            Collectivite = collectivite
        };

        return await _mentionResRepository.AddAsync(newMention);
    }

    private async Task<MotsCle> GetOrCreateMotsCle(string motCle)
    {
        var existing = await _motsCleRepository.FindFirstAsync(m => m.MotCle == motCle);

        if (existing != null)
            return existing;

        var newMot = new MotsCle
        {
            MotCle = ReplaceSpecialChars(motCle),
            IsIndexed = 0
        };

        return await _motsCleRepository.AddAsync(newMot);
    }

    private async Task<Ville> GetOrCreateVille(string villeName)
    {
        if (string.IsNullOrEmpty(villeName))
            return null;

        var existing = await _villeRepository.FindFirstAsync(v => v.Ville1 == villeName);

        if (existing != null)
            return existing;

        var newVille = new Ville
        {
            Ville1 = ReplaceSpecialChars(villeName)
        };

        return await _villeRepository.AddAsync(newVille);
    }

    private async Task<Editeur> GetOrCreateEditeur(string editeurName)
    {
        if (string.IsNullOrEmpty(editeurName))
            return null;

        var existing = await _editeurRepository.FindFirstAsync(e => e.Editeur1 == editeurName);

        if (existing != null)
            return existing;

        var newEditeur = new Editeur
        {
            Editeur1 = ReplaceSpecialChars(editeurName)
        };

        return await _editeurRepository.AddAsync(newEditeur);
    }
}
