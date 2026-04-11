using System;
using System.Collections.Generic;

namespace Common.Models;

public partial class PaysPublication
{
    public decimal IdNotice { get; set; } 

    public string IdPays { get; set; } = string.Empty;

    public virtual Notice Notice { get; set; } = null!;
    public virtual Pay Pay { get; set; } = null!;
}
