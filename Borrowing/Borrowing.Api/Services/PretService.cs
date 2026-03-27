using Borrowing.SharedClasses.Common;
using Borrowing.SharedClasses.Requests.Pret;
using Borrowing.SharedClasses.Responses.Pret;
using Borrowing.Api.Repositories;
using Shared.Models;
using Microsoft.EntityFrameworkCore;

namespace Borrowing.Api.Services;

public interface IPretService
{
    Task<Pret?> CreatePretAsync(CreatePretRequestDto pretRequestDTo);
    Task<int> CountAsync();
    Task<PagedResult<PretResponseDto>> GetPretsAsync(PretQueryParameters queryParameters);

    Task<int> CountAdherentActiveLoans(string AdherentId);

    Task<List<Pret>> GetBlockedCopies(string cote);
    // Task<Pret?> GetPretByExemplaireId(string IdExemplaire);

}

public class PretService : IPretService
{
    private readonly IPretRepository _pretRepository;
    private readonly IHistoriquePretRepository _historiquePretRepository;
    private readonly IExemplairesRepository _exemplairesRepository;
    private readonly IAdherentRepository _adherentRepository;
    private readonly IPositionRepository _positionRepository;
    private readonly ICategorieRepository _categorieRepository;
    private readonly INoticesRepository _noticesRepository;

    public PretService(
        IPretRepository pretRepository,
        IHistoriquePretRepository historiquePretRepository,
        IExemplairesRepository exemplairesRepository,
        IAdherentRepository adherentRepository,
        IPositionRepository positionRepository,
        ICategorieRepository categorieRepository,
        INoticesRepository noticesRepository)
    {
        _pretRepository = pretRepository;
        _historiquePretRepository = historiquePretRepository;
        _exemplairesRepository = exemplairesRepository;
        _adherentRepository = adherentRepository;
        _positionRepository = positionRepository;
        _categorieRepository = categorieRepository;
        _noticesRepository = noticesRepository;
    }

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

    public async Task<PagedResult<PretResponseDto>> GetPretsAsync(PretQueryParameters queryParameters)
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

                "titre asc" => query.OrderBy(x => x.NoticeTitrePropre),
                "titre desc" => query.OrderByDescending(x => x.NoticeTitrePropre),
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

}