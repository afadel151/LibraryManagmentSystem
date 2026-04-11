namespace Borrowing.SharedClasses.Models.User;


public class CurrentUserResponseDto
{
    public bool IsAuthenticated { get; set; }
    public string? Name { get; set; }
    public string? Role { get; set; }
    public string? Nom { get; set; }
}