using System;
using System.Collections.Generic;

namespace LibraryManagement.Common.Models;

public partial class Etablissement
{
    public decimal IdEtablissement { get; set; }

    public string? Etablissement1 { get; set; }

    public virtual ICollection<NoticeDipDisEtab> NoticeDipDisEtabs { get; set; } = [];
}
