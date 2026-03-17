using System;
using System.Collections.Generic;

namespace Shared.Models;

public partial class Discipline
{
    public decimal IdDiscipline { get; set; }

    public string? Discipline1 { get; set; }

    public virtual ICollection<NoticeDipDisEtab> NoticeDipDisEtabs { get; set; } = new List<NoticeDipDisEtab>();
}
