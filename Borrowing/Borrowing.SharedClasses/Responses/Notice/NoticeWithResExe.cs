namespace Borrowing.SharedClasses.Responses.Notice;
using LibraryManagement.Shared.Models;
public class NoticeWithResExe
{
    public Notice? Notice { get; set; }
    public List<Reservation> Reservations { get; set; } = new();
    public List<Exemplaire> Exemplaires { get; set; } = new();
}