
namespace Borrowing.Api.Tests.Providers;

public interface IDateTimeProvider
{
    DateTime Today { get; }
}

public class DateTimeProvider : IDateTimeProvider
{
    public DateTime Today => DateTime.Now.Date;
}