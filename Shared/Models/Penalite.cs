using System;
using System.Collections.Generic;

namespace LibraryManagement.Common.Models;

public partial class Penalite
{
    public string IdCategorie { get; set; } = null!;

    public decimal JoursRetard { get; set; }

    public decimal? NombreJoursRetard { get; set; }

    public virtual Categorie Categorie { get; set; } = null!;
}
