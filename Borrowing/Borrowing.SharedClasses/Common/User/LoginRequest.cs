namespace Borrowing.SharedClasses.Models;

using Common.Models;
public class LoginRequest
{
    public string compte {get;set;} = string.Empty;
    public string motdepasse {get;set;} = string.Empty;
}
