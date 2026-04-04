namespace Borrowing.SharedClasses.Common;

using Shared.Models;
public class LoginRequest
{
    public string compte {get;set;} = string.Empty;
    public string motdepasse {get;set;} = string.Empty;
}
