using System;
using System.Collections.Generic;

namespace Common.Models;

public partial class SelectionNotice
{
    public decimal IdNotice {get;set;}

    public decimal IdSelection {get;set;}


    public virtual  Notice Notice { get; set; } = null!;
    public virtual  Selection Selection { get; set; } = null!;

}