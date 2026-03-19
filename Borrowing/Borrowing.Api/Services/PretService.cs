using Borrowing.Api.DTOs;
using Borrowing.Api.Repositories;
using Shared.Models;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace Borrowing.Api.Services;

public interface IPretService
{
    Task<Pret?> CreatePretAsync(Pret pret);
    Task<PagedResult<PretResponseDto>> GetPretsAsync(PretQueryParameters queryParameters);
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

    public async Task<Pret?> CreatePretAsync(Pret pret)
    {
        await _pretRepository.AddAsync(pret);
        return pret;
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
                        AdherentNom = a.Nom ?? string.Empty,
                        AdherentPrenom = a.Prenom ?? string.Empty,
                        AdherentPosition = pos != null ? pos.LibellePosition ?? string.Empty : string.Empty,
                        AdherentCategorie = c != null ? c.LibelleCategorie ?? string.Empty : string.Empty,
                        NoticeTitrePropre = n != null ? n.TitrePropre ?? string.Empty : string.Empty,
                        DatePret = p.DatePret,
                        EtatDuree = p.EtatDuree
                    };

        // Apply ordering
        if (!string.IsNullOrWhiteSpace(queryParameters.OrderBy))
        {
            query = queryParameters.OrderBy.ToLower() switch
            {
                "datepret desc" => query.OrderByDescending(x => x.DatePret),
                "datepret asc" => query.OrderBy(x => x.DatePret),
                "nom desc" => query.OrderByDescending(x => x.AdherentNom),
                "nom asc" => query.OrderBy(x => x.AdherentNom),
                "titre desc" => query.OrderByDescending(x => x.NoticeTitrePropre),
                "titre asc" => query.OrderBy(x => x.NoticeTitrePropre),
                _ => query.OrderByDescending(x => x.DatePret) // Default ordering
            };
        }
        else
        {
            query = query.OrderByDescending(x => x.DatePret); // Default ordering
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
}