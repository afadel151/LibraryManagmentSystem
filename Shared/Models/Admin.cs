using System;
using System.Collections.Generic;

namespace LibraryManagement.Shared.Models;

public partial class Admin
{
    public string IdAdmin { get; set; } = null!;

    public string? Password { get; set; }
}
