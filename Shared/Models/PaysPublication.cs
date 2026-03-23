using System;
using System.Collections.Generic;

namespace Shared.Models;

public partial class PaysPublication
{
    public decimal IdNotice { get; set; } 

    public string IdPays { get; set; } = string.Empty;

    public virtual Notice IdNoticeNavigation { get; set; } = null!;
    public virtual Pay IdPaysNavigation { get; set; } = null!;
}
