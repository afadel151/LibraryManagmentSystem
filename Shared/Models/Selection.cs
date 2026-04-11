using System;
using System.Collections.Generic;

namespace LibraryManagement.Common.Models;

public partial class Selection
{
    public decimal IdSelection { get; set; }

    public string? LibelleSelection { get; set; }

    public virtual ICollection<Notice> Notices { get; set; } = [];

}
