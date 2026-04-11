namespace Borrowing.SharedClasses.Responses.Adherent;

using System;

using Common.Models;
public class AdherentsStatsDto
{
    public int TotalActif {get;set;}
    public int Pretants {get;set;}
    public int Penalises {get;set;}
    public int Suspended {get;set;}

}