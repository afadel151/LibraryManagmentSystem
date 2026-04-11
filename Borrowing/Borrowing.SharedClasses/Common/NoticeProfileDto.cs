namespace Borrowing.SharedClasses.Models;

using Common.Models;
public class NoticeProfileDto
{
    public Notice Notice {get;set;} = null!;
    public List<Exemplaire> Exemplaires {get;set;} = [];
    public List<Reservation> Reservations {get;set;} = [];
}   