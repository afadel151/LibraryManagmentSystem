using System;
using System.Collections.Generic;

namespace Shared.Models;

public partial class MentionResponsabilite
{
    public decimal IdMentionRes { get; set; }

    public string? Nom { get; set; }

    public string? AutrePartie { get; set; }

    public decimal? Collectivite { get; set; }

    public virtual ICollection<AuteurSecondaire> AuteurSecondaires { get; set; } = new List<AuteurSecondaire>();
    public virtual ICollection<MentionResCollection> MentionResCollections { get; set; } = new List<MentionResCollection>();
    public virtual ICollection<Auteur> Auteurs { get; set; } = new List<Auteur>();
    public virtual ICollection<CoAuteur> CoAuteurs { get; set; } = new List<CoAuteur>();


}
