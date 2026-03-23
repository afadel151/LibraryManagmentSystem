using System;
using System.Collections.Generic;

namespace Shared.Models;

public partial class SelectionNotice
{
    public decimal IdNotice { get; set; }

    public decimal IdSelection  { get; set; }

    public virtual Notice IdNoticeNavigation { get; set; } = null!;
    public virtual Selection IdSelectionNavigation { get; set; } = null!;

}
