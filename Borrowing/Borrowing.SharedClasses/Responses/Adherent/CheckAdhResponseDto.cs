namespace Borrowing.SharedClasses.Responses.Adherent;

using System;

using Shared.Models;
public class CheckAdhResponseDto
{
    public bool Allowed { get; set; } = false;
    public string message {get; set;} = string.Empty;
    public Adherent? Adherent {get; set;}
    public bool Found {get;set;} = true;
    public string picture {get;set;} = string.Empty;
    public int ActiveLoans {get;set;} = 0;
    public DateTime ExpectedReturnDate {get;set;} = DateTime.Now.Date;
}
