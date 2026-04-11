using System;
using System.Collections.Generic;

namespace Common.Models;

public partial class NoticeMentionEdition
{
    public decimal IdNotice { get; set; }

    public string? MentionEdition { get; set; }

    public virtual Notice Notice {get;set;} = null!;
}
