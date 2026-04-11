using System;
using System.Collections.Generic;

namespace LibraryManagement.Common.Models;

public partial class Admin
{
    public string IdAdmin { get; set; } = null!;

    public string? Password { get; set; }
}
