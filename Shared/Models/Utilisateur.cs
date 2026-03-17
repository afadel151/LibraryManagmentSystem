using System;
using System.Collections.Generic;

namespace Shared.Models;

public partial class Utilisateur
{
    public string Compte { get; set; } = null!;

    public string Motdepasse { get; set; } = null!;

    public string Nom { get; set; } = null!;

    public string Column1 { get; set; } = null!;

    public string? Email { get; set; }

    public DateTime Datecrerationcompte { get; set; }
}
