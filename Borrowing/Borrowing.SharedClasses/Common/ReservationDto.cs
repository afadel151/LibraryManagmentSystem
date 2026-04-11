namespace Borrowing.SharedClasses.Models;

using Common.Models;
public class ReservationDto
{
    public string IdAdherent { get; set; } = null!;
    public string Nom { get; set; } = null!;
    public string Prenom { get; set; } = null!;
    public string Cote { get; set; } = null!;
    public string TitrePropre { get; set; } = null!;
    public DateTime HeureReservation { get; set; }

}