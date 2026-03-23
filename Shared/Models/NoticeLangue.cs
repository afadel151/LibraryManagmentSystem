using System;
using System.Collections.Generic;

namespace Shared.Models;

public partial class NoticeLangue
{
    public decimal IdNotice { get; set; }

    public string IdLangue { get; set; } = string.Empty;

    public virtual Notice IdNoticeNavigation { get; set; } = null!;
    public virtual Langue IdLangueNavigation { get; set; } = null!;

}
