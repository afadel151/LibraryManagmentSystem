namespace Borrowing.SharedClasses.Common.User;


public class CurrentUserResponseDto
{
    public bool IsAuthenticated { get; set; }
    public string? Name { get; set; }
    public string? Role { get; set; }
    public string? Nom { get; set; }
}