using System;
using System.Collections.Generic;

namespace LibraryManagement.Shared.Models;

public partial class MotsCle
{
    public decimal IdMotCle { get; set; }

    public string? MotCle { get; set; }

    public decimal? IsIndexed { get; set; }

    public virtual ICollection<Notice> Notices { get; set; } = [];
}
