using System;
using System.Collections.Generic;

namespace Shared.Models;

public partial class HistoriquePret
{
    public string IdAdherent { get; set; } = null!;

    public string IdExemplaire { get; set; } = null!;

    public DateTime DatePret { get; set; }

    public DateTime? DateRetour { get; set; }
}
