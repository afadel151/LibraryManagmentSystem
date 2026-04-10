
using System.Text.Json.Serialization;
using Borrowing.SharedClasses.Common;

namespace Borrowing.Api.Services;

// not in use
public interface ICalendarificService
{
    Task<List<CalendarificHoliday>> GetHolidaysForYearAsync(int year, string country = "DZ", string language = "en");
}

public class CalendarificService(HttpClient httpClient, IConfiguration configuration) : ICalendarificService
{
    private readonly HttpClient _httpClient = httpClient;
    private readonly string _apiKey = configuration["Calendarific:ApiKey"]!;

    public async Task<List<CalendarificHoliday>> GetHolidaysForYearAsync(int year, string country = "DZ", string language = "en")
    {
        var url = $"https://calendarific.com/api/v2/holidays?api_key={_apiKey}&country={country}&year={year}&type=national,religious&language={language}";
        var response = await _httpClient.GetFromJsonAsync<CalendarificResponse>(url);

        return response?.Response?.Holidays
            .Select(h => new CalendarificHoliday(
                h.Name,
                h.Description,
                h.Date.Iso))
            .ToList() ?? [];
    }
}

file class CalendarificResponse
{
    [JsonPropertyName("response")]
    public CalendarificResponseBody? Response { get; set; }
}
file class CalendarificResponseBody
{
    [JsonPropertyName("holidays")]
    public List<CalendarificHolidayRaw> Holidays { get; set; } = [];
}
file class CalendarificHolidayRaw
{
    [JsonPropertyName("name")]
    public string Name { get; set; } = "";
    [JsonPropertyName("description")]
    public string Description { get; set; } = "";
    [JsonPropertyName("date")]
    public CalendarificDate Date { get; set; } = new();
}
file class CalendarificDate
{
    [JsonPropertyName("iso")]
    public string Iso { get; set; } = "";
}