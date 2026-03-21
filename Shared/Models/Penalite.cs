using System;
using System.Collections.Generic;

namespace Shared.Models;

public partial class Penalite
{
    public string IdCategorie { get; set; } = null!;

    public decimal JoursRetard { get; set; }

    public decimal? NombreJoursRetard { get; set; }
}
