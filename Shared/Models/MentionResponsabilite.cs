using System;
using System.Collections.Generic;

namespace Shared.Models;

public partial class MentionResponsabilite
{
    public decimal IdMentionRes { get; set; }

    public string? Nom { get; set; }

    public string? AutrePartie { get; set; }

    public decimal? Collectivite { get; set; }

    // many to many 
    public virtual ICollection<AuteurSecondaire> AuteurSecondaires {get;set;} = [];
    public virtual ICollection<Collection> Collections { get; set; } = [];
    public virtual ICollection<Notice> AuteurNotices { get; set; } = [];    
    public virtual ICollection<Notice> CoAuteurNotices { get; set; } = [];
    public virtual ICollection<Notice> AuteurSecondaireNotices { get; set; } = [];


}
