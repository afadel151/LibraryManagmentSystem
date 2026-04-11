namespace Borrowing.SharedClasses.Common;

using LibraryManagement.Common.Models;
public class LoginRequest
{
    public string compte {get;set;} = string.Empty;
    public string motdepasse {get;set;} = string.Empty;
}
