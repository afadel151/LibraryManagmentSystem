using System;
using System.Collections.Generic;

namespace Common.Models;

public partial class Exemplaire
{
    public string IdExemplaire { get; set; } = null!;

    public decimal? IdEtat { get; set; }

    public string? Cote { get; set; }

    public virtual EtatExemplaire? EtatExemplaire { get; set; }

    public virtual ICollection<Pret> Prets { get; set; } = [];
    public virtual ICollection<HistoriquePret> HistoriquePrets { get; set; } = [];

    public virtual Notice Notice { get; set; } = null!;
}