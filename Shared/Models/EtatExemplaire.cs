using System;
using System.Collections.Generic;

namespace LibraryManagement.Common.Models;

public partial class EtatExemplaire
{
    public decimal IdEtat { get; set; }

    public string? LibelleEtat { get; set; }

    public virtual ICollection<Exemplaire> Exemplaires { get; set; } = [];
}
