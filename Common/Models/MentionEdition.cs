using System;
using System.Collections.Generic;

namespace Common.Models;

public partial class MentionEdition
{
    public decimal IdNotice { get; set; }

    public string? Mention { get; set; }

    public virtual Notice Notice { get; set; } = null!;
}
