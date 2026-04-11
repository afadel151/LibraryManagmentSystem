using System;
using System.Collections.Generic;

namespace Common.Models;

public partial class HistoriquePenaliteAdherent
{
    public string IdAdherent { get; set; } = null!;

    public DateTime DatePenalite { get; set; }

    public decimal? NombreJoursPenalite { get; set; }

    public virtual Adherent Adherent {get;set;} = null!;
}
