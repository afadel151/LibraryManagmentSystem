using System;
using System.Collections.Generic;

namespace Common.Models;

public partial class Fonction
{
    public decimal IdFonction { get; set; }

    public string? Fonction1 { get; set; }

    public virtual ICollection<AuteurSecondaire> AuteurSecondaires { get; set; } = [];
    public virtual ICollection<Notice> Notices {get;set;} = null!;
    public virtual ICollection<MentionResponsabilite> MentionResponsabilites{ get; set; } = [];

}
