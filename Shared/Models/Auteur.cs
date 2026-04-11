using System;
using System.Collections.Generic;

namespace LibraryManagement.Shared.Models;

public partial class Auteur
{
    public decimal IdNotice { get; set; }

    public decimal IdMentionRes { get; set; }

    public virtual Notice Notice { get; set; } = null!;
    public virtual MentionResponsabilite MentionResponsabilite { get; set; } = null!;
}
