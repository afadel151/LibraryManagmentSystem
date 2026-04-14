using Borrowing.Api.Repositories;
using Common.Models;
using Microsoft.EntityFrameworkCore;
using Borrowing.SharedClasses.Models;
using Borrowing.SharedClasses.Requests.JoursFery;
using Borrowing.Api.Extensions;

namespace Borrowing.Api.Services;

public interface IJoursFeriesService
{
    Task<PagedResult<JoursFeryDto>> GetJoursFeriesAsync(PaginatedQueryParameters queryParameters);
    Task<IEnumerable<JoursFeryDto>> GetAllJoursFeriesAsync();
    Task<bool> CreateJoursFeryAsync(CreateJoursFeryDto dto);
    Task<bool> UpdateJoursFeryAsync(UpdateJoursFeryDto dto);
    Task<bool> DeleteJoursFeryAsync(DateTime dateJourFerie);
}

public class JoursFeriesService(IJoursFeriesRepository joursFeriesRepository,ILogger<JoursFeriesService> logger) : IJoursFeriesService
{
    private readonly IJoursFeriesRepository _joursFeriesRepository = joursFeriesRepository;
    private readonly ILogger<JoursFeriesService> _logger = logger;

    public async Task<PagedResult<JoursFeryDto>> GetJoursFeriesAsync(PaginatedQueryParameters queryParameters)
    {
        ArgumentNullException.ThrowIfNull(queryParameters);
        var joursFeries = _joursFeriesRepository.GetQueryable()
            .Where(p =>
                    string.IsNullOrEmpty(queryParameters.Search) ||
                    EF.Functions.Like(p.DateJourFerie.ToString("dd/MM/yyyy"), "%" + queryParameters.Search + "%")
            );

        var query = from jf in joursFeries
                    select new JoursFeryDto
                    {
                        DateJourFerie = jf.DateJourFerie
                    };

        var totalCount = await query.CountAsync();

        if (!string.IsNullOrWhiteSpace(queryParameters.OrderBy))
        {
            query = queryParameters.OrderBy.ToUpper() switch
            {
                "DATEJOURFERIE ASC" => query.OrderBy(x => x.DateJourFerie),
                "DATEJOURFERIE DESC" => query.OrderByDescending(x => x.DateJourFerie),
                _ => query.OrderBy(x => x.DateJourFerie)
            };
        }
        else
        {
            query = query.OrderBy(x => x.DateJourFerie);
        }

        var data = await query
            .Skip((queryParameters.PageNumber - 1) * queryParameters.PageSize)
            .Take(queryParameters.PageSize)
            .ToListAsync();

        return new PagedResult<JoursFeryDto>
        {
            Data = data,
            TotalCount = totalCount,
            PageNumber = queryParameters.PageNumber,
            PageSize = queryParameters.PageSize
        };
    }

    public async Task<IEnumerable<JoursFeryDto>> GetAllJoursFeriesAsync()
    {
        var joursFeries = await _joursFeriesRepository.GetQueryable()
            .OrderBy(jf => jf.DateJourFerie)
            .ToListAsync();

        return joursFeries.Select(jf => new JoursFeryDto
        {
            DateJourFerie = jf.DateJourFerie
        });
    }

    public async Task<bool> CreateJoursFeryAsync(CreateJoursFeryDto dto)
    {
        ArgumentNullException.ThrowIfNull(dto);
        var existingJoursFery = await _joursFeriesRepository.GetQueryable()
            .FirstOrDefaultAsync(jf => jf.DateJourFerie == dto.DateJourFerie);

        if (existingJoursFery != null)
        {
            return false; // Already exists
        }

        var joursFery = new JoursFery
        {
            DateJourFerie = dto.DateJourFerie
        };

        try
        {
            await _joursFeriesRepository.AddAsync(joursFery);
            return true;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex.Message);
            return false;
        }
    }

    public async Task<bool> UpdateJoursFeryAsync(UpdateJoursFeryDto dto)
    {
        ArgumentNullException.ThrowIfNull(dto);
        var joursFery = await _joursFeriesRepository.GetQueryable()
            .FirstOrDefaultAsync(jf => jf.DateJourFerie == dto.DateJourFerie);

        if (joursFery == null) return false;

        // For this simple model, there's nothing to update as the date is the key
        // This method exists for consistency with the pattern

        return true;
    }

    public async Task<bool> DeleteJoursFeryAsync(DateTime dateJourFerie)
    {
        var joursFery = await _joursFeriesRepository.GetQueryable()
            .FirstOrDefaultAsync(jf => jf.DateJourFerie == dateJourFerie);

        if (joursFery == null) return false;

        try
        {
            await _joursFeriesRepository.DeleteAsync(joursFery);
            return true;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex.Message);
            return false;
        }
    }
}