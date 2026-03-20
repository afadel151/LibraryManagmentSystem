namespace Borrowing.Shared.Responses.Pret;
using System;


public class PretResponseDto
{
    public string AdherentNom { get; set; } = string.Empty;
    public string AdherentPrenom { get; set; } = string.Empty;
    public string AdherentCategorie { get; set; } = string.Empty;
    public string NoticeTitrePropre { get; set; } = string.Empty;
    public string NoticeCote { get; set; } = string.Empty;
    public DateTime DatePret { get; set; }
    public string? EtatDuree { get; set; }
}
