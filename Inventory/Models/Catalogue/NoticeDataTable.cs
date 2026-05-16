namespace Inventory.Models.Catalogue;

public class NoticeDataTableRequest
{
    public int Draw { get; set; }
    public int Start { get; set; }
    public int Length { get; set; }
    public string? Search { get; set; }        // global search
    public string? FilterTitre { get; set; }
    public string? FilterCote { get; set; }
    public string? FilterIsbn { get; set; }
    public string? FilterType { get; set; }
    public string? FilterUnindexed { get; set; } // "true" when coming from dashboard
    public string? OrderColumn { get; set; }   // "cote" | "titre" | "type"
    public string? OrderDir { get; set; }      // "asc" | "desc"
}

public class NoticeDataTableResult
{
    public int Draw { get; set; }
    public int RecordsTotal { get; set; }
    public int RecordsFiltered { get; set; }
    public IEnumerable<NoticeRowDto> Data { get; set; } = [];
}

public class NoticeRowDto
{
    public decimal IdNotice { get; set; }
    public string Cote { get; set; } = "";
    public string TitrePropre { get; set; } = "";
    public string TypeNotice { get; set; } = "";
    public string Accessibilite { get; set; } = "";
    public int IsIndexed { get; set; }
    public int HasExemplaires { get; set; }
}