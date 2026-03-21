using System;
using System.Collections.Generic;

namespace Shared.Models;

public partial class Aquisition
{
    public string NumCommande { get; set; } = null!;

    public string IdExemplaire { get; set; } = null!;

    public string? PrixUnitaire { get; set; }
}
