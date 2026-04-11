using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;

namespace Common.Models;

public partial class Reservation
{
    public string IdAdherent { get; set; } = null!;

    public string Cote { get; set; } = null!;

    public DateTime HeureReservation { get; set; }

    public Adherent Adherent {get;set;} = null!;
    
    [NotMapped]
    public Notice Notice {get;set;} = null!;
}
