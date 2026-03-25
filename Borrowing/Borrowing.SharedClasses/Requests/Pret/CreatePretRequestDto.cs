namespace Borrowing.SharedClasses.Requests.Pret;
public class CreatePretRequestDto
{
    public string AdherentId { get; set; } = string.Empty;
    public string ExemplaireId { get; set; } = string.Empty;
    public DateTime DatePret { get; set; } = DateTime.Now;
}
