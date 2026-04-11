namespace Borrowing.SharedClasses.Responses.Adherent;

using System;

using Common.Models;
public class AdherentProfileDto
{
    public Adherent? Adherent {get;set;}

    public string Picture {get;set;} = string.Empty;    
}