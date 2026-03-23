using System;
using System.Collections.Generic;

namespace Shared.Models;

public partial class Pay
{
    public string IdPays { get; set; } = null!;

    public string? Pays { get; set; }

    public virtual ICollection<Notice> IdNotices { get; set; } = new List<Notice>();

    public virtual ICollection<PaysPublication> PaysPublications { get; set; } = new List<PaysPublication>();
}
