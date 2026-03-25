namespace Borrowing.SharedClasses.Responses.Notice;
using Shared.Models;
public class CheckNoticeResponseDto
{
    public string Message {get;set;} = string.Empty;

    public bool Found {get;set;} = true;
    public List<string> Exemplaires {get;set;} = [];
    public bool Reservateur {get;set;} = false;
    public bool CanBorrow {get;set;} = false;

    public bool CanReserve {get;set;} = false;
    public string Titre {get;set;} = string.Empty;
}