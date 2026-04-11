namespace Borrowing.SharedClasses.Requests.Reservation;

public class CreateReservationRequestDto
{
    public string AdherentId { get; set; } = string.Empty;
    public string Cote { get; set; } = string.Empty;
    public DateTime HereReservation { get; set; } = DateTime.Now;
}
