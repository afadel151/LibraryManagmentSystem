namespace Borrowing.SharedClasses.Responses.Adherent;

using System;

using Shared.Models;
using Borrowing.SharedClasses.Common;
public class CheckAdhResponseDto
{
    public EtatAdherentEnum Etat { get; set; } = EtatAdherentEnum.NOT_FOUND;
    public Adherent? Adherent {get; set;}
    public string picture {get;set;} = string.Empty;
    public int ActiveLoans {get;set;} = 0;
    public DateTime ExpectedReturnDate {get;set;} = DateTime.Now.Date;
}
