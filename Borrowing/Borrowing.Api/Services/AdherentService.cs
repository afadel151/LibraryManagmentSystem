using Borrowing.Api.Repositories;
using Common.Models;
using Microsoft.EntityFrameworkCore;
using Borrowing.SharedClasses.Models;
using Borrowing.SharedClasses.Responses.Adherent;
using Borrowing.SharedClasses.Requests.Adherent;
using Borrowing.Api.Extensions;
namespace Borrowing.Api.Services;

public interface IAdherentService
{
    Task<PagedResult<AdherentDto>> GetAdherentsAsync(PaginatedQueryParameters queryParameters);
    Task<AdherentProfileDto?> GetAdherentWithDetailsAsync(string adherentId);
    Task<DateTime> CalculateExpectedReturnDate(DateTime startDate, decimal duration);
    Task<Adherent?> GetAdherentWithPretsPenaliteAsync(string AdherentId);
    Task<AdherentsStatsDto> GetStats();
    Task<bool> CreateAdherentAsync(CreateAdherentDto dto);
    Task<bool> UpdateAdherentAsync(UpdateAdherentDto dto);

    Task<CheckAdhPretResponseDto> CheckAdherentPourPret(string id);
}

public class AdherentService(
    IAdherentRepository adherentRepository,
    IJoursFeriesRepository joursFeriesRepository,
    IPretRepository pretRepository,
    ILogger<AdherentService> logger
) : IAdherentService
{
    private readonly IAdherentRepository _adherentRepository = adherentRepository;
    private readonly IJoursFeriesRepository _joursFeriesRepository = joursFeriesRepository;
    private readonly IPretRepository _pretRepository = pretRepository;
    private readonly ILogger<AdherentService> _logger = logger;



    public async Task<PagedResult<AdherentDto>> GetAdherentsAsync(PaginatedQueryParameters queryParameters)
    {
        ArgumentNullException.ThrowIfNull(queryParameters);
        var adherents = _adherentRepository.GetQueryable(a => a.Categorie!, a => a.Position!, a => a.PenaliteAdherents, a => a.Reservations, a => a.Prets)
            .Where(p =>
                    string.IsNullOrEmpty(queryParameters.Search) ||
                    EF.Functions.Like(p.IdAdherent.ToUpper(), queryParameters.Search.ToUpper() + "%") ||
                    EF.Functions.Like(p.Nom!.ToUpper(), queryParameters.Search.ToUpper() + "%") ||
                    EF.Functions.Like(p.Prenom!.ToUpper(), queryParameters.Search.ToUpper() + "%")
            );
        var query = from a in adherents
                    select new AdherentDto
                    {
                        IdAdherent = a.IdAdherent,
                        Nom = a.Nom ?? string.Empty,
                        Prenom = a.Prenom ?? string.Empty,
                        Position = a.Position!.LibellePosition ?? string.Empty,
                        Categorie = a.Categorie!.LibelleCategorie ?? string.Empty,
                        Etat = (int)a.EtatAdherent!,
                        Prets = a.Prets.Count,
                        Reservations = a.Reservations.Count,
                    };
        var totalCount = await query.CountAsync();
        if (!string.IsNullOrWhiteSpace(queryParameters.OrderBy))
        {
            query = queryParameters.OrderBy.ToUpper() switch
            {
                "IDADHERENT ASC" => query.OrderBy(x => x.IdAdherent),
                "IDADHERENT DESC" => query.OrderByDescending(x => x.IdAdherent),


                "NOM ASC" => query.OrderBy(x => x.Nom),
                "NOM DESC" => query.OrderByDescending(x => x.Nom),

                "PRENOM ASC" => query.OrderBy(x => x.Prenom),
                "PRENOM DESC" => query.OrderByDescending(x => x.Prenom),

                "CATEGORIE ASC" => query.OrderBy(x => x.Categorie),
                "CATEGORIE DESC" => query.OrderByDescending(x => x.Categorie),

                "POSITION ASC" => query.OrderBy(x => x.Position!),
                "POSITION DESC" => query.OrderByDescending(x => x.Position!),

                "ETAT ASC" => query.OrderBy(x => x.Etat),
                "ETAT DESC" => query.OrderByDescending(x => x.Etat),

                "PRETS ASC" => query.OrderBy(x => x.Prets),
                "PRETS DESC" => query.OrderByDescending(x => x.Prets),

                "RESERVATIONS ASC" => query.OrderBy(x => x.Reservations),
                "RESERVATIONS DESC" => query.OrderByDescending(x => x.Reservations),
                _ => query.OrderBy(x => x.IdAdherent)
            };
        }
        else
        {
            query = query.OrderBy(x => x.IdAdherent); // default
        }

        var data = await query
            .Skip((queryParameters.PageNumber - 1) * queryParameters.PageSize)
            .Take(queryParameters.PageSize)
            .ToListAsync();

        return new PagedResult<AdherentDto>
        {
            Data = data,
            TotalCount = totalCount,
            PageNumber = queryParameters.PageNumber,
            PageSize = queryParameters.PageSize
        };

    }
    public async Task<AdherentProfileDto?> GetAdherentWithDetailsAsync(string adherentId)
    {
        ArgumentNullException.ThrowIfNull(adherentId);
        var adherent = await _adherentRepository.GetQueryable(a => a.Categorie!, a => a.Position!, a => a.PenaliteAdherents, a => a.HistoriquePenaliteAdherents, a => a.Reservations, a => a.Prets, a => a.HistoriquePrets).FirstOrDefaultAsync(a => a.IdAdherent == adherentId);

        if (adherent != null)
        {
            return new AdherentProfileDto
            {
                Adherent = adherent,
                Picture = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcQBy606CYdQuQNTxOH0mHl6Lxdker4OH8Nvvg&s"
            };
        }
        return null;
    }


    public async Task<DateTime> CalculateExpectedReturnDate(DateTime startDate, decimal duration)
    {
        var rawReturnDate = startDate.AddDays((double)duration);
        List<JoursFery> joursFeries = await _joursFeriesRepository.GetQueryable().ToListAsync();
        return BaseExtensions.Traiter_date(rawReturnDate, joursFeries);
    }


    public async Task<AdherentsStatsDto> GetStats()
    {
        int penalises = await _adherentRepository.GetQueryable()
                        .Where(a => a.EtatAdherent == 2)
                            .CountAsync();

        int suspended = await _adherentRepository.GetQueryable()
                        .Where(a => a.EtatAdherent == 3)
                            .CountAsync();

        int totalActifs = await _adherentRepository.GetQueryable()
                        .Where(a => a.EtatAdherent == 1)
                            .CountAsync();

        int pretants = await _pretRepository.GetQueryable()
                        .GroupBy(p => p.IdAdherent)
                        .CountAsync();

        return new AdherentsStatsDto
        {
            TotalActif = totalActifs,
            Penalises = penalises,
            Pretants = pretants,
            Suspended = suspended
        };

    }
    public async Task<Adherent?> GetAdherentWithPretsPenaliteAsync(string AdherentId)
    {
        ArgumentNullException.ThrowIfNull(AdherentId);
        var adherent = await _adherentRepository.GetQueryable(a => a.Prets, a => a.PenaliteAdherents, a => a.Categorie!)
                        .Where(a => a.IdAdherent == AdherentId)
                        .FirstOrDefaultAsync();
        if (adherent == null)
        {
            return null;
        }
        return adherent;
    }

    public async Task<bool> CreateAdherentAsync(CreateAdherentDto dto)
    {
        ArgumentNullException.ThrowIfNull(dto);
        var adherent = new Adherent
        {
            IdAdherent = dto.IdAdherent,
            Nom = dto.Nom,
            Prenom = dto.Prenom,
            IdPosition = dto.IdPosition,
            IdCategorie = dto.IdCategorie,
            EtatAdherent = 1 // Active
        };

        try
        {
            await _adherentRepository.AddAsync(adherent);
            return true;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex.Message);
            return false; // Typically duplicate key exception or generic DB error
        }
    }

    public async Task<bool> UpdateAdherentAsync(UpdateAdherentDto dto)
    {
        ArgumentNullException.ThrowIfNull(dto);
        var adherent = await _adherentRepository.GetQueryable()
                        .FirstOrDefaultAsync(a => a.IdAdherent == dto.IdAdherent);

        if (adherent == null) return false;

        adherent.Nom = dto.Nom;
        adherent.Prenom = dto.Prenom;
        adherent.IdPosition = dto.IdPosition;
        adherent.IdCategorie = dto.IdCategorie;
        adherent.EtatAdherent = dto.EtatAdherent;

        try
        {
            await _adherentRepository.UpdateAsync(adherent);
            return true;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex.Message);
            return false;
        }
    }

    public async Task<CheckAdhPretResponseDto> CheckAdherentPourPret(string id)
    {
        ArgumentNullException.ThrowIfNull(id);
        var adherent = await GetAdherentWithDetailsAsync(id);
        if (adherent != null)
        {
            if (adherent.Adherent?.EtatAdherent == 1) // actif
            {
                if (adherent.Adherent?.Categorie != null) // categorie exists
                {
                    int activeLoans = adherent.Adherent.Prets.Count; // count active loans
                    if (activeLoans < adherent.Adherent?.Categorie.NombreDocument)
                    {
                        DateTime expectedReturnDate = await CalculateExpectedReturnDate(DateTime.Now.Date, (decimal)adherent.Adherent?.Categorie.DureePret!);
                        return new CheckAdhPretResponseDto
                        {
                            Etat = CheckAdherentEnum.AUTHORIZED,
                            Adherent = adherent.Adherent,
                            picture = adherent.Picture,
                            ActiveLoans = activeLoans,
                            ExpectedReturnDate = expectedReturnDate

                        };
                    }
                    else
                    {
                        return new CheckAdhPretResponseDto
                        {
                            Etat = CheckAdherentEnum.QUOTA_REACHED,
                            Adherent = adherent.Adherent,
                            picture = adherent.Picture,
                            ActiveLoans = activeLoans
                        };
                    }
                }
                else
                {
                    return new CheckAdhPretResponseDto
                    {
                        Etat = CheckAdherentEnum.NOT_FOUND,
                    };

                }

            }
            else if (adherent.Adherent?.EtatAdherent == 2)
            {
                return new CheckAdhPretResponseDto
                {
                    Etat = CheckAdherentEnum.PENALISED,
                    Adherent = adherent.Adherent,
                    picture = adherent.Picture
                };

            }
            else
            {
                return new CheckAdhPretResponseDto
                {
                    Etat = CheckAdherentEnum.SUSPENDED,
                    Adherent = adherent.Adherent,
                    picture = adherent.Picture
                };
            }
        }
        else
        {
            return new CheckAdhPretResponseDto
            {
                Etat = CheckAdherentEnum.NOT_FOUND,
            };
        }
    }
}