using System;
using System.Collections.Generic;

namespace Shared.Models;

public partial class Exemplaire
{
    public string IdExemplaire { get; set; } = null!;

    public decimal? IdEtat { get; set; }

    public string? Cote { get; set; }

    public virtual EtatExemplaire? EtatExemplaire { get; set; }

    public virtual ICollection<Pret> Prets { get; set; } = new List<Pret>(); 
    public virtual ICollection<HistoriquePret> HistoriquePrets { get; set; } = new List<HistoriquePret>(); 

    public virtual Notice Notice {get;set;} = null!;
}