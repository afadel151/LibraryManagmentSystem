
namespace Borrowing.SharedClasses.Models;
public class ApiResult
{
    public bool Success { get; set; }
    public string? Message { get; set; }
    public string? ErrorCode { get; set; }

    public static ApiResult Ok(string? message = null) => new() { Success = true, Message = message };
    public static ApiResult Fail(string message, string? errorCode = null) => new() { Success = false, Message = message, ErrorCode = errorCode };
}