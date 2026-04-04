using Borrowing.Api.Repositories;
using Borrowing.SharedClasses.Responses.Position;
using Microsoft.EntityFrameworkCore;

namespace Borrowing.Api.Services;

public interface IPositionService
{
    Task<IEnumerable<PositionDto>> GetAllPositionsAsync();
}

public class PositionService(IPositionRepository positionRepository) : IPositionService
{
    private readonly IPositionRepository _positionRepository = positionRepository;

    public async Task<IEnumerable<PositionDto>> GetAllPositionsAsync()
    {
        return await _positionRepository.GetQueryable()
            .Select(p => new PositionDto
            {
                IdPosition = p.IdPosition,
                LibellePosition = p.LibellePosition ?? string.Empty
            })
            .ToListAsync();
    }
}
