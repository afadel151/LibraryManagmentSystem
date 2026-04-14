using Borrowing.Api.Repositories;
using Microsoft.EntityFrameworkCore;
using Common.Models;
using Borrowing.SharedClasses.Models;
using Borrowing.SharedClasses.Requests.Penalite;
using System.Data.Common;

namespace Borrowing.Api.Services;

public interface IPenaliteService
{
    Task<PagedResult<PenaliteDto>> GetPenalitesAsync(PaginatedQueryParameters queryParameters);
    Task<IEnumerable<PenaliteDto>> GetAllPenalitesAsync();
    Task<bool> CreatePenaliteAsync(CreatePenaliteDto dto);
    Task<bool> UpdatePenaliteAsync(UpdatePenaliteDto dto);
    Task<bool> DeletePenaliteAsync(string idCategorie);
}

public class PenaltieService(
    IPenaliteRepository penaliteRepository,
    ILogger<PenaltieService> logger
 ) : IPenaliteService
{
    private readonly IPenaliteRepository _penaliteRepository = penaliteRepository;
    private readonly ILogger<PenaltieService> _logger = logger;
    public async Task<PagedResult<PenaliteDto>> GetPenalitesAsync(PaginatedQueryParameters queryParameters)
    {
        ArgumentNullException.ThrowIfNull(queryParameters);
        var penalites = _penaliteRepository.GetQueryable(p => p.Categorie!)
            .Where(p =>
                    string.IsNullOrEmpty(queryParameters.Search) ||
                    EF.Functions.Like(p.Categorie!.LibelleCategorie ?? "", "%" + queryParameters.Search + "%") ||
                    EF.Functions.Like(p.IdCategorie, "%" + queryParameters.Search + "%")
            );

        var query = from p in penalites
                    select new PenaliteDto
                    {
                        IdCategorie = p.IdCategorie,
                        LibelleCategorie = p.Categorie!.LibelleCategorie ?? string.Empty,
                        JoursRetard = p.JoursRetard,
                        NombreJoursRetard = p.NombreJoursRetard
                    };

        var totalCount = await query.CountAsync();

        if (!string.IsNullOrWhiteSpace(queryParameters.OrderBy))
        {
            query = queryParameters.OrderBy.ToUpper() switch
            {
                "IDCATEGORIe ASC" => query.OrderBy(x => x.IdCategorie),
                "IDCATEGORIE DESC" => query.OrderByDescending(x => x.IdCategorie),
                "LIBELLECATEGORIE ASC" => query.OrderBy(x => x.LibelleCategorie),
                "LIBELLECATEGORIE DESC" => query.OrderByDescending(x => x.LibelleCategorie),
                "JOURSRETARD ASC" => query.OrderBy(x => x.JoursRetard),
                "JOURSRETARD DESC" => query.OrderByDescending(x => x.JoursRetard),
                "NOMBREJOURSRETARD ASC" => query.OrderBy(x => x.NombreJoursRetard),
                "NOMBREJOURSRETARD DESC" => query.OrderByDescending(x => x.NombreJoursRetard),
                _ => query.OrderBy(x => x.IdCategorie)
            };
        }
        else
        {
            query = query.OrderBy(x => x.IdCategorie);
        }

        var data = await query
            .Skip((queryParameters.PageNumber - 1) * queryParameters.PageSize)
            .Take(queryParameters.PageSize)
            .ToListAsync();

        return new PagedResult<PenaliteDto>
        {
            Data = data,
            TotalCount = totalCount,
            PageNumber = queryParameters.PageNumber,
            PageSize = queryParameters.PageSize
        };
    }

    public async Task<IEnumerable<PenaliteDto>> GetAllPenalitesAsync()
    {
        var penalites = await _penaliteRepository.GetQueryable(p => p.Categorie!)
            .OrderBy(p => p.IdCategorie)
            .ToListAsync();

        return penalites.Select(p => new PenaliteDto
        {
            IdCategorie = p.IdCategorie,
            LibelleCategorie = p.Categorie!.LibelleCategorie ?? string.Empty,
            JoursRetard = p.JoursRetard,
            NombreJoursRetard = p.NombreJoursRetard
        });
    }

    public async Task<bool> CreatePenaliteAsync(CreatePenaliteDto dto)
    {
        ArgumentNullException.ThrowIfNull(dto);
        var existingPenalite = await _penaliteRepository.GetQueryable()
            .FirstOrDefaultAsync(p => p.IdCategorie == dto.IdCategorie);

        if (existingPenalite != null)
        {
            return false; // Already exists
        }

        var penalite = new Penalite
        {
            IdCategorie = dto.IdCategorie,
            JoursRetard = dto.JoursRetard,
            NombreJoursRetard = dto.NombreJoursRetard
        };

        try
        {
            await _penaliteRepository.AddAsync(penalite);
            return true;
        }
        catch (DbException ex)
        {
            _logger.LogError(ex.Message);
            return false;
        }
    }

    public async Task<bool> UpdatePenaliteAsync(UpdatePenaliteDto dto)
    {
        ArgumentNullException.ThrowIfNull(dto);
        var penalite = await _penaliteRepository.GetQueryable()
            .FirstOrDefaultAsync(p => p.IdCategorie == dto.IdCategorie);

        if (penalite == null) return false;

        penalite.JoursRetard = dto.JoursRetard;
        penalite.NombreJoursRetard = dto.NombreJoursRetard;

        try
        {
            await _penaliteRepository.UpdateAsync(penalite);
            return true;
        }
         catch (DbException ex)
        {
            _logger.LogError(ex.Message);
            return false;
        }
    }

    public async Task<bool> DeletePenaliteAsync(string idCategorie)
    {
        ArgumentNullException.ThrowIfNull(idCategorie);
        var penalite = await _penaliteRepository.GetQueryable()
            .FirstOrDefaultAsync(p => p.IdCategorie == idCategorie);

        if (penalite == null) return false;

        try
        {
            await _penaliteRepository.DeleteAsync(penalite);
            return true;
        }
         catch (DbException ex)
        {
            _logger.LogError(ex.Message);
            return false;
        }
    }
}