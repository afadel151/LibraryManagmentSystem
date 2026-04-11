using Borrowing.Api.Repositories;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Common.Models;

namespace Borrowing.Api.Services;

public interface IRestitutionService
{
}

public class RestitutionService(
    IPretRepository pretRepository,
    IExemplairesRepository exemplairesRepository,
    IPenaliteAdherentRepository penaliteAdherentRepository,
    IAdherentRepository adherentRepository
    ) : IRestitutionService
{
    private readonly IPretRepository _pretRepository = pretRepository;
    private readonly IExemplairesRepository _exemplairesRepository = exemplairesRepository;
    private readonly IPenaliteAdherentRepository _penaliteAdherentRepository = penaliteAdherentRepository;
    private readonly IAdherentRepository _adherentRepository = adherentRepository;

   
}