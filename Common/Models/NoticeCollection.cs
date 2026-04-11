using System;
using System.Collections.Generic;

namespace Common.Models;

public partial class NoticeCollection
{
    public decimal IdNotice { get; set; }

    public decimal IdCollection { get; set; }

    public string? NumeroDansCollection { get; set; }

    public virtual Collection Collection { get; set; } = null!;

    public virtual Notice Notice { get; set; } = null!;
}
