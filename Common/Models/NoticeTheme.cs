using System;
using System.Collections.Generic;

namespace Common.Models;

public partial class NoticeTheme
{
    public decimal IdNotice { get; set; }

    public string IdTheme { get; set; } = null!;
     public virtual Theme Theme { get; set; } = null!;

    public virtual Notice Notice { get; set; } = null!;
}
