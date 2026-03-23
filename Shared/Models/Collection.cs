using System;
using System.Collections.Generic;

namespace Shared.Models;

public partial class Collection
{
    public decimal IdCollection { get; set; }

    public string? TitreCollection { get; set; }

    public string? SousTitreCollection { get; set; }

    public string? IssnCollection { get; set; }

    public virtual ICollection<NoticeCollection> NoticeCollections { get; set; } = new List<NoticeCollection>();
    public virtual ICollection<Collection> Collections { get; set; } = new List<Collection>();
    public virtual ICollection<MentionResCollection> MentionResCollections { get; set; } = new List<MentionResCollection>();


}
