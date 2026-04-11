using System;
using System.Collections.Generic;

namespace LibraryManagement.Common.Models;

public partial class Pay
{
    public string IdPays { get; set; } = null!;

    public string? Pays { get; set; }

    
    public virtual ICollection<Notice> Notices { get; set; } = [];
}
