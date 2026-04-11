namespace Borrowing.SharedClasses.Responses.Adherent;

using System;

using Common.Models;
using Borrowing.SharedClasses.Models;
public class CheckAdhRestitutionResponseDto
{
    public bool Found { get; set; } = true;
    public Adherent? Adherent { get; set; }
    public string Picture { get; set; } = string.Empty;
}
