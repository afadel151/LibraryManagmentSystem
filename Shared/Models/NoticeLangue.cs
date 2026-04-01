using System;
using System.Collections.Generic;

namespace Shared.Models;

public partial class NoticeLangue
{
    
    public decimal IdNotice {get;set;}

    public string IdLangue {get;set;} = null!;

    public virtual Notice Notice { get; set; } = null!;
    public virtual Langue Langue { get; set; } = null!;
    


}