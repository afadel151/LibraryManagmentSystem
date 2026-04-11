using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
namespace LibraryManagement.Shared.Models;

public partial class EtatAdherent
{
    [Key]
    public int IdEtat { get; set; }

    public string? DescEtat { get; set; }
}
