namespace Borrowing.SharedClasses.Reservation.Pret;
public class CreateReservationRequestDto
{
    public string AdherentId { get; set; } = string.Empty;
    public string NoticeId { get; set; } = string.Empty;
    public DateTime HereReservation { get; set; } = DateTime.Now;
}
