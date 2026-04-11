using System;
using System.Collections.Generic;

namespace Common.Models;

public partial class Adherent
{
    public Adherent()
    {
        PenaliteAdherents = new List<PenaliteAdherent>();
        Prets = new List<Pret>();
        Reservations = new List<Reservation>();
    }   
    public string IdAdherent { get; set; } = null!;

    public string? Nom { get; set; }

    public string? Prenom { get; set; }

    public decimal? IdPosition { get; set; }

    public string? IdCategorie { get; set; }

    public decimal? EtatAdherent { get; set; }

    public virtual ICollection<HistoriqueAuth> HistoriqueAuths { get; set; } = [];
    public virtual ICollection<HistoriquePret> HistoriquePrets { get; set; } = [];
    public virtual ICollection<HistoriquePenaliteAdherent> HistoriquePenaliteAdherents { get; set; } = [];
    public virtual ICollection<PenaliteAdherent> PenaliteAdherents { get;set; } = [];
    public virtual ICollection<Reservation> Reservations { get; set; } = [];
    public virtual ICollection<Pret> Prets { get; set; } = [];
    public virtual Position? Position { get; set; }
    public virtual Categorie? Categorie { get; set; }

}
