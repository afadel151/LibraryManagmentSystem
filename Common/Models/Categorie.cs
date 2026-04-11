using System;
using System.Collections.Generic;

namespace Common.Models;

public partial class Categorie
{
    public string IdCategorie { get; set; } = null!;

    public string? LibelleCategorie { get; set; }

    public decimal? NombreDocument { get; set; }

    public decimal? DureePret { get; set; }

    public virtual ICollection<Adherent> Adherents {get;set;} = [];

    public virtual ICollection<Penalite> Penalites { get;set; } = [];
}
