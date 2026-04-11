namespace Borrowing.SharedClasses.Responses.Notice;
using LibraryManagement.Common.Models;
public class NoticeWithResExe
{
    public Notice? Notice { get; set; }
    public List<Reservation> Reservations { get; set; } = [];
    public List<Exemplaire> Exemplaires { get; set; } = [];
}