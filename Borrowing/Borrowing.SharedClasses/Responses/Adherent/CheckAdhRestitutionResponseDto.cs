namespace Borrowing.SharedClasses.Responses.Adherent;

using System;

using LibraryManagement.Common.Models;
using Borrowing.SharedClasses.Common;
public class CheckAdhRestitutionResponseDto
{
    public bool Found {get;set;} = true;
    public Adherent? Adherent {get; set;}
    public string Picture {get;set;} = string.Empty;
}
