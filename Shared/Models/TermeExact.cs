using System;
using System.Collections.Generic;

namespace LibraryManagement.Shared.Models;

public partial class TermeExact
{
    public decimal IdTermeExact { get; set; }

    public string? TermeExact1 { get; set; }
    public virtual ICollection<Notice> Notices { get; set; } = new List<Notice>();

}
