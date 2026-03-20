namespace Borrowing.Shared.Responses.Adherent;
using System;



public class CheckAdhRequestDto
{
    public bool Available { get; set; } = false;
    public DateTime ExpectedDate {get;set;} = DateTime.Today;
}
