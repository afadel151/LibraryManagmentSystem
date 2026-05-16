using System.Text.RegularExpressions;
using Common.Models;
using Inventory.Models.Catalogue.Add;
using Inventory.Repositories;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
namespace Inventory.Services;

public record ServiceResult<T>(bool Success, T? Value, string? Error)
{
    public static ServiceResult<T> Ok(T value) => new(true, value, null);
    public static ServiceResult<T> Fail(string e) => new(false, default, e);
}


public interface IPeriodiqueService
{
    Task<ServiceResult<Notice>> CreatePeriodiqueAsync(PeriodiqueViewModel model);
    Task<PeriodiqueViewModel> PopulateFormOptionsAsync(PeriodiqueViewModel model);
}


public sealed class PeriodiqueService(
    INoticeRepository noticeRepository,
    IMentionResRepository mentionResRepository,
    IVilleRepository villeRepository,
    IEditeurRepository editeurRepository,
    IMotsCleRepository motsCleRepository,
    ILangueRepository langueRepository,
    IThemeRepository themeRepository,
    IPaysRepository paysRepository,
    IPeriodiciteRepository periodiciteRepository,
    IFonctionRepository fonctionRepository
) : IPeriodiqueService
{

    public async Task<ServiceResult<Notice>> CreatePeriodiqueAsync(PeriodiqueViewModel model)
    {
        var existingNotice = await noticeRepository.FindFirstAsync(n =>
            n.Cote != null &&
            n.Cote.ToUpper() == model.Cote);

        if (existingNotice is not null)
            return ServiceResult<Notice>.Fail(
                $"La cote « {model.Cote} » existe déjà dans la base.");

        var auteurPrincipal = await ResolveAuteurPrincipalAsync(model);
        var coAuteurs = await ResolveCoAuteursAsync(model);
        var autSecondaires = await ResolveAuteursSecondairesAsync(model);
        var motsCles = await ResolveMotsClesAsync(model);
        var langues = await ResolveLanguesAsync(model);
        var pays = await ResolvePaysAsync(model);
        var theme = await ResolveThemeAsync(model);
        var editions = await ResolveEditionsAsync(model);

        var maxId = await noticeRepository.GetQueryable().MaxAsync(n => (int?)n.IdNotice) ?? 0;
        var nextId = maxId + 1;
        var notice = new Notice
        {
            IdNotice = nextId,
            IdType = 1,
            Cote = model.Cote,
            IdPeriodicite = string.IsNullOrWhiteSpace(model.ID_Periodicite)
                                         ? null : model.ID_Periodicite,
            TitrePropre = Sanitize(model.TitrePropre),
            TitreCle = Sanitize(model.TitreCle),
            SousTitre = Sanitize(model.SousTitre),
            IssnNotice = Sanitize(model.ISSN),
            Date1erPub = Sanitize(model.Date1Pub),
            NumeroVol = Sanitize(model.NumeroVol),
            NbrExemple = model.NbrExemplaires,
            Accessibilite = model.Accessibilite ? "1" : "0",
            Localisation = Sanitize(model.Localisation),
            CollationImpMaterielle = Sanitize(model.CollationImpMaterielle),
            CollationAutresCarMat = Sanitize(model.CollationAutresCarMat),
            CollationFormat = Sanitize(model.CollationFormat),
            Resume = Sanitize(model.Resume),
            NoteGenerale = Sanitize(model.NoteGenerale),
            Cdd = string.IsNullOrWhiteSpace(model.CDD)
                                         ? null : model.CDD.Trim(),
            IsIndexed = 0,
            ExemplaireExiste = 0,
        };

        // if (auteurPrincipal is not null)
        //     notice.Auteurs.Add(auteurPrincipal);

        // foreach (var ca in coAuteurs)
        //     notice.CoAuteurs.Add(ca);

        // foreach (var (mention, fonctionId) in autSecondaires)
        //     notice.AuteurSecondaires.Add(new AuteurSecondaire
        //     {
        //         IdMentionRes = mention.IdMentionRes,
        //         IdFonction = fonctionId,
        //     });

        // foreach (var mot in motsCles)
        //     notice.MotsCles.Add(mot);

        // foreach (var langue in langues)
        //     notice.Langues.Add(langue);

        // foreach (var p in pays)
        //     notice.Pays.Add(p);

        // if (theme is not null)
        //     notice.NoticeThemes.Add(new NoticeTheme { IdTheme = theme.IdTheme });

        // foreach (var ed in editions)
        //     notice.NoticeEditions.Add(ed);

        // if (!string.IsNullOrWhiteSpace(model.MentionEdition))
        //     notice.NoticeMentionEdition = new NoticeMentionEdition
        //     {
        //         MentionEdition = Sanitize(model.MentionEdition),
        //     };

        var created = await noticeRepository.AddAsync(notice);
        return ServiceResult<Notice>.Ok(created);
    }


    private async Task<MentionResponsabilite?> ResolveAuteurPrincipalAsync(
        PeriodiqueViewModel model)
    {
        ArgumentNullException.ThrowIfNull(model.IdAuteurPrincipal);
        return await GetOrCreateMentionResAsync(model.IdAuteurPrincipal);
    }

    private async Task<List<MentionResponsabilite>> ResolveCoAuteursAsync(
        PeriodiqueViewModel model)
    {
        var result = new List<MentionResponsabilite>();
        if (model.IdCoAuteurs.Count == 0) return result;

        foreach (var ca in model.IdCoAuteurs)
        {
            var mention = await GetOrCreateMentionResAsync(ca);

            if (!result.Any(m => m.IdMentionRes == mention!.IdMentionRes))
                result.Add(mention!);
        }

        return result;
    }

    private async Task<List<(MentionResponsabilite Mention, decimal IdFonction)>>
        ResolveAuteursSecondairesAsync(PeriodiqueViewModel model)
    {
        var result = new List<(MentionResponsabilite Mention, decimal IdFonction)>();
        if (model.AuteursSecondaires is null) return result;

        foreach (var item in model.AuteursSecondaires)
        {
            var mention = await GetOrCreateMentionResAsync(item.IdMentionRes);

            bool alreadyIn = result.Any(r =>
                r.Mention.IdMentionRes == mention!.IdMentionRes &&
                r.IdFonction == item.ID_Fonction);

            if (!alreadyIn)
                result.Add((mention!, item.ID_Fonction));
        }

        return result;
    }

    private async Task<List<MotsCle>> ResolveMotsClesAsync(PeriodiqueViewModel model)
    {
        var result = new List<MotsCle>();
        if (model.MotsCles is null) return result;

        foreach (var raw in model.MotsCles
                     .Where(m => !string.IsNullOrWhiteSpace(m)))
        {
            var mot = await GetOrCreateMotsCleAsync(raw.Trim());
            if (!result.Any(m => m.IdMotCle == mot.IdMotCle))
                result.Add(mot);
        }

        return result;
    }

    private async Task<List<Langue>> ResolveLanguesAsync(PeriodiqueViewModel model)
    {
        var result = new List<Langue>();
        if (model.LangueCodes is null) return result;

        foreach (var code in model.LangueCodes
                     .Where(c => !string.IsNullOrWhiteSpace(c)))
        {
            // Langues are looked up by their ISO PK — unknown codes are skipped
            var langue = await langueRepository.GetByIdAsync(code.ToUpper().Trim());
            if (langue is not null && !result.Any(l => l.IdLangue == langue.IdLangue))
                result.Add(langue);
        }

        return result;
    }

    private async Task<List<Pay>> ResolvePaysAsync(PeriodiqueViewModel model)
    {
        var result = new List<Pay>();
        if (model.PaysCodes is null) return result;

        foreach (var code in model.PaysCodes
                     .Where(c => !string.IsNullOrWhiteSpace(c)))
        {
            var pay = await paysRepository.GetByIdAsync(code.ToUpper().Trim());
            if (pay is not null && !result.Any(p => p.IdPays == pay.IdPays))
                result.Add(pay);
        }

        return result;
    }

    private async Task<Theme?> ResolveThemeAsync(PeriodiqueViewModel model)
    {
        if (string.IsNullOrWhiteSpace(model.ID_Theme))
            return null;

        var existing = await themeRepository.GetByIdAsync(model.ID_Theme.Trim());
        if (existing is not null)
            return existing;

        // Only create if the user supplied a label for the new theme
        if (string.IsNullOrWhiteSpace(model.ThemeLabel))
            return null;

        return await themeRepository.AddAsync(new Theme
        {
            IdTheme = model.ID_Theme.Trim(),
            Theme1 = Sanitize(model.ThemeLabel)!,
        });
    }

    private async Task<List<NoticeEdition>> ResolveEditionsAsync(
        PeriodiqueViewModel model)
    {
        var result = new List<NoticeEdition>();
        if (model.AdressesBibliographiques is null) return result;

        foreach (var adresse in model.AdressesBibliographiques
                     .Where(a => !string.IsNullOrWhiteSpace(a.NomVille)
                              || !string.IsNullOrWhiteSpace(a.NomEditeur)))
        {
            var ville = await GetOrCreateVilleAsync(adresse.NomVille);
            var editeur = await GetOrCreateEditeurAsync(adresse.NomEditeur);

            if (ville is null || editeur is null)
                continue;

            bool alreadyIn = result.Any(e =>
                e.IdVille == ville.IdVille && e.IdEditeur == editeur.IdEditeur);

            if (!alreadyIn)
                result.Add(new NoticeEdition
                {
                    IdVille = ville.IdVille,
                    IdEditeur = editeur.IdEditeur,
                    DateEdition = string.Empty, // Pascal: DATE_EDITION = '' for périodiques
                });
        }

        return result;
    }
    private async Task<MentionResponsabilite?> GetOrCreateMentionResAsync(decimal? Id)
    {
        var existing = await mentionResRepository.FindFirstAsync(m => m.IdMentionRes == Id);
        return existing;
    }

    private async Task<MotsCle> GetOrCreateMotsCleAsync(string motCle)
    {
        var clean = Sanitize(motCle)!;
        var existing = await motsCleRepository.FindFirstAsync(m =>
            m.MotCle != null &&
            m.MotCle.ToUpper() == clean.ToUpper());

        if (existing is not null)
            return existing;

        return await motsCleRepository.AddAsync(new MotsCle
        {
            MotCle = clean,
            IsIndexed = 0,
        });
    }

    private async Task<Ville?> GetOrCreateVilleAsync(string? name)
    {
        if (string.IsNullOrWhiteSpace(name)) return null;
        var clean = Sanitize(name)!;

        var existing = await villeRepository.FindFirstAsync(v =>
            v.Ville1 != null &&
            v.Ville1.ToUpper() == clean.ToUpper());

        return existing ?? await villeRepository.AddAsync(new Ville { Ville1 = clean });
    }

    private async Task<Editeur?> GetOrCreateEditeurAsync(string? name)
    {
        if (string.IsNullOrWhiteSpace(name)) return null;
        var clean = Sanitize(name)!;

        var existing = await editeurRepository.FindFirstAsync(e =>
            e.Editeur1 != null &&
            e.Editeur1.ToUpper() == clean.ToUpper());

        return existing ?? await editeurRepository.AddAsync(new Editeur { Editeur1 = clean });
    }

    private static string? Sanitize(string? input)
    {
        if (input is null) return null;
        var trimmed = Regex.Replace(input.Trim(), @"\s{2,}", " ");
        return trimmed.Length == 0 ? null : trimmed;
    }


    public async Task<PeriodiqueViewModel> PopulateFormOptionsAsync(PeriodiqueViewModel model)
    {



        var allPays = (await paysRepository.GetAllAsync()).OrderBy(p => p.Pays).ToList();
        var allFonctions = (await fonctionRepository.GetAllAsync()).OrderBy(p => p.Fonction1).ToList();
        var allThemes = (await themeRepository.GetAllAsync()).OrderBy(t => t.Theme1).ToList();
        var allLangues = (await langueRepository.GetAllAsync()).OrderBy(l => l.Langue1).ToList();
        var allPeriodicite = (await periodiciteRepository.GetAllAsync()).OrderBy(l => l.Periodicite1).ToList();
        var allMentions = (await mentionResRepository.GetAllAsync())
                            .OrderBy(m => m.Nom)
                            .ThenBy(m => m.AutrePartie)
                            .ToList();

        model.PaysOptions = allPays
            .Select(p => new SelectListItem(
                text: p.Pays ?? p.IdPays,
                value: p.IdPays))
            .ToList();

        model.ThemeOptions = allThemes
            .Select(t => new SelectListItem(
                text: t.Theme1 ?? t.IdTheme,
                value: t.IdTheme))
            .ToList();

        model.FonctionOptions = allFonctions
            .Select(t => new SelectListItem(
                text: t.Fonction1,
                value: t.IdFonction.ToString()))
            .ToList();

        model.LangueOptions = allLangues
            .Select(l => new SelectListItem(
                text: l.Langue1 ?? l.IdLangue,
                value: l.IdLangue))
            .ToList();
        model.PeriodiciteOptions = allPeriodicite
            .Select(l => new SelectListItem(
                text: l.Periodicite1 ?? l.IdPeriodicite,
                value: l.IdPeriodicite))
            .ToList();
        var mentionOptions = allMentions
            .Select(m =>
            {
                var label = string.IsNullOrWhiteSpace(m.AutrePartie)
                    ? m.Nom ?? "—"
                    : $"{m.Nom}, {m.AutrePartie}";

                if (m.Collectivite != 0)
                    label += " [C]";

                return new SelectListItem(
                    text: label,
                    value: m.IdMentionRes.ToString());
            })
            .ToList();

        model.AllMentionRes = mentionOptions;
        return model;
    }
}