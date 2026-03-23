namespace Borrowing.SharedClasses.Requests.Pret;
public class CreatePretRequestDTo
{
    public string AdherentId { get; set; } = string.Empty;
    public string NoticeId { get; set; } = string.Empty;
    public DateTime DatePret { get; set; } = DateTime.Now;
    public DateTime DateRetourPrevu { get; set; } = DateTime.Now.AddDays(30);
}
