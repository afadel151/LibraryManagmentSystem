using System;
using System.Collections.Generic;

namespace LibraryManagement.Shared.Models;

public partial class Terme
{
    public decimal IdTerme { get; set; }

    public string? Terme1 { get; set; }

    public virtual ICollection<Notice> Notices { get; set; } = new List<Notice>();
}
