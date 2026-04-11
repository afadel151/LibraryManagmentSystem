namespace Borrowing.SharedClasses.Responses.Adherent;

using System;

using Common.Models;
using Borrowing.SharedClasses.Models;
public class CheckAdhPretResponseDto
{
    public CheckAdherentEnum Etat { get; set; } = CheckAdherentEnum.NOT_FOUND;
    public Adherent? Adherent {get; set;}
    public string picture {get;set;} = string.Empty;
    public int ActiveLoans {get;set;}
    public DateTime ExpectedReturnDate {get;set;} = DateTime.Now.Date;
}
