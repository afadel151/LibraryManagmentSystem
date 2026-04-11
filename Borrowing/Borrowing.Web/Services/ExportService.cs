// Services/ExportService.cs
using ClosedXML.Excel;
using Microsoft.JSInterop;
using System.Reflection;
// Services/IExportService.cs

namespace Borrowing.Web.Services;

public interface IExportService
{
    Task ExportToExcelAsync<T>(IEnumerable<T> data, string fileName, string sheetName = "Sheet1");
}
public class ExportService(IJSRuntime js) : IExportService
{
    private readonly IJSRuntime _js = js;

    public async Task ExportToExcelAsync<T>(IEnumerable<T> data, string fileName, string sheetName = "Sheet1")
    {
        using var workbook = new XLWorkbook();
        var worksheet = workbook.Worksheets.Add(sheetName);

        var properties = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance);

        // Header row
        for (int i = 0; i < properties.Length; i++)
        {
            var cell = worksheet.Cell(1, i + 1);
            cell.Value = properties[i].Name;
            cell.Style.Font.Bold = true;
            cell.Style.Fill.BackgroundColor = XLColor.FromHtml("#4472C4");
            cell.Style.Font.FontColor = XLColor.White;
        }

        // Data rows
        var list = data.ToList();
        for (int row = 0; row < list.Count; row++)
        {
            for (int col = 0; col < properties.Length; col++)
            {
                var value = properties[col].GetValue(list[row]);
                worksheet.Cell(row + 2, col + 1).Value = value switch
                {
                    null => XLCellValue.FromObject(""),
                    DateTime dt => dt.ToString("dd/MM/yyyy HH:mm"),
                    DateOnly d => d.ToString("dd/MM/yyyy"),
                    _ => XLCellValue.FromObject(value)
                };
            }
        }

        worksheet.Columns().AdjustToContents();

        using var stream = new MemoryStream();
        workbook.SaveAs(stream);
        var bytes = stream.ToArray();

        await _js.InvokeVoidAsync("downloadFileFromBytes", fileName + ".xlsx", Convert.ToBase64String(bytes));
    }
}