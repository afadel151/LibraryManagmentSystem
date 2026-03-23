using System;
using System.Collections.Generic;

namespace Shared.Models;

public partial class CoAuteur
{
    public decimal IdNotice { get; set; }

    public decimal IdMentionRes { get; set; }

    public virtual Notice IdNoticeNavigation { get; set; } = null!;
    public virtual MentionResponsabilite IdMentionResNavigation { get; set; } = null!;

}
