using System;
using System.Collections.Generic;

namespace Shared.Models;

public partial class MentionResCollection
{
    public decimal IdCollection { get; set; }

    public decimal IdMentionRes { get; set; }

    public virtual Collection IdCollectionNavigation { get; set; } = null!;
    public virtual MentionResponsabilite IdMentionResNavigation { get; set; } = null!;

}
