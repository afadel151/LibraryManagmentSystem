namespace Borrowing.SharedClasses.Responses.Notice;
using Shared.Models;
public class CheckNoticeDto
{
    public Notice? Notice { get; set; }
    public List<Reservation> Reservations { get; set; } = new();
    public List<Exemplaire> Exemplaires { get; set; } = new();
}