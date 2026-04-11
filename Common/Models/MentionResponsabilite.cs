using System;
using System.Collections.Generic;

namespace Common.Models;

public partial class MentionResponsabilite
{
    public decimal IdMentionRes { get; set; }

    public string? Nom { get; set; }

    public string? AutrePartie { get; set; }

    public decimal? Collectivite { get; set; }

    // many to many 
    public virtual ICollection<AuteurSecondaire> AuteurSecondaires {get;set;} = [];
    public virtual ICollection<Collection> Collections { get; } = [];
    public virtual ICollection<Notice> AuteurNotices { get; } = [];    
    public virtual ICollection<Notice> CoAuteurNotices { get; } = [];
    public virtual ICollection<Notice> AuteurSecondaireNotices { get; } = [];


}
