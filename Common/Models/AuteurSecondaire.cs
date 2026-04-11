using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Common.Models;

public partial class AuteurSecondaire
{
    public decimal IdNotice { get; set; }

    public decimal IdMentionRes { get; set; }

  
    public decimal IdFonction { get; set; }

    public virtual Fonction Fonction { get; set; } = null!;

    public virtual MentionResponsabilite MentionResponsabilite { get; set; } = null!;

    public virtual Notice Notice { get; set; } = null!;
}
