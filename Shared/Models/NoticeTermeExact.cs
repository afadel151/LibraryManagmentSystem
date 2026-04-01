using System;
using System.Collections.Generic;

namespace Shared.Models;

public partial class NoticeTermeExact
{
    public decimal IdTermeExact { get; set; }

    public decimal IdNotice { get; set; }

    public decimal? PoidsTerme { get; set; }

    public virtual TermeExact TermeExact { get; set; } = null!;
    public virtual Notice Notice { get; set; } = null!;


}
