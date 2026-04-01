using System;
using System.Collections.Generic;

namespace Shared.Models;

public partial class Selection
{
    public decimal IdSelection { get; set; }

    public string? LibelleSelection { get; set; }

    public virtual ICollection<Notice> Notices { get; set; } = new List<Notice>();

}
