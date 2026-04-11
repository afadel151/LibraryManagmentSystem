using System;
using System.Collections.Generic;

namespace Common.Models;

public partial class MentionResCollection
{
    public decimal IdCollection { get; set; }

    public decimal IdMentionRes { get; set; }

    public virtual Collection Collection { get; set; } = null!;
    public virtual MentionResponsabilite MentionResponsabilite { get; set; } = null!;

}
