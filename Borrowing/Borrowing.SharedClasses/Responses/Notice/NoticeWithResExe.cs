namespace Borrowing.SharedClasses.Responses.Notice;
using Common.Models;
public class NoticeWithResExe
{
    public Notice? Notice { get; set; }
    public List<Reservation> Reservations { get; } = [];
    public List<Exemplaire> Exemplaires { get; } = [];
}