using System;
using System.Collections.Generic;

namespace Shared.Models;

public partial class TableCdd
{
    public string Cdd { get; set; } = null!;

    public string? Libelle { get; set; }

    public ICollection<Notice> Notices {get;set;} = [];     
}
