using System;
using System.Collections.Generic;

namespace Common.Models;

public partial class Adherent
{
    public string IdAdherent { get; set; } = null!;

    public string? Nom { get; set; }

    public string? Prenom { get; set; }

    public decimal? IdPosition { get; set; }

    public string? IdCategorie { get; set; }

    public decimal? EtatAdherent { get; set; }

    public virtual ICollection<HistoriqueAuth> HistoriqueAuths { get; } = [];
    public virtual ICollection<HistoriquePret> HistoriquePrets { get; } = [];    
    public virtual ICollection<HistoriquePenaliteAdherent> HistoriquePenaliteAdherents { get; } = [];    
    public virtual ICollection<PenaliteAdherent> PenaliteAdherents { get; } = [];
    public virtual ICollection<Reservation> Reservations { get; } = [];    
    public virtual ICollection<Pret> Prets { get; } = [];    
    public virtual Position? Position { get; set; }
    public virtual Categorie? Categorie { get; set; }

}
