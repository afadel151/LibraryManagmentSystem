using System;
using System.Collections.Generic;

namespace Shared.Models;

public partial class Admin
{
    public string IdAdmin { get; set; } = null!;

    public string? Password { get; set; }
}
