namespace Borrowing.SharedClasses.Responses.Adherent;

using System;

using Shared.Models;
public class AdherentsStatsDto
{
    public int TotalActif {get;set;} = 0;
    public int Penalises {get;set;} = 0;
    public int Pretants {get;set;} = 0;

}