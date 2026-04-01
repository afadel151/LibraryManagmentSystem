using System;
using System.Collections.Generic;

namespace Shared.Models;

public partial class Collection
{
    public decimal IdCollection { get; set; }

    public string? TitreCollection { get; set; }

    public string? SousTitreCollection { get; set; }

    public string? IssnCollection { get; set; }

    public virtual ICollection<Notice> Notices { get; set; } = new List<Notice>();
    public virtual ICollection<MentionResponsabilite> MentionResponsabilites { get; set; } = new List<MentionResponsabilite>();


}
