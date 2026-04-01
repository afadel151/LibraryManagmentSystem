using System;
using System.Collections.Generic;

namespace Shared.Models;

public partial class NoticeEdition
{
    public decimal IdVille { get; set; }

    public decimal IdEditeur { get; set; }

    public decimal IdNotice { get; set; }

    public string? DateEdition { get; set; }

    public virtual Editeur Editeur { get; set; } = null!;

    public virtual Notice Notice { get; set; } = null!;

    public virtual Ville Ville { get; set; } = null!;
}
