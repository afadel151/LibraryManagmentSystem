using System;
using System.Collections.Generic;

namespace LibraryManagement.Shared.Models;

public partial class Editeur
{
    public decimal IdEditeur { get; set; }

    public string? Editeur1 { get; set; }

    public virtual ICollection<NoticeEdition> NoticeEditions { get; set; } = [];
}
