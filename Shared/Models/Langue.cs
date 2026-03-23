using System;
using System.Collections.Generic;

namespace Shared.Models;

public partial class Langue
{
    public string IdLangue { get; set; } = null!;

    public string? Langue1 { get; set; }

    public virtual ICollection<Notice> IdNotices { get; set; } = new List<Notice>();

    public virtual ICollection<NoticeLangue> NoticeLangues { get; set; } = new List<NoticeLangue>();
}
