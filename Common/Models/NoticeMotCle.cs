using System;
using System.Collections.Generic;

namespace Common.Models;

public partial class NoticeMotCle
{
    public decimal IdNotice { get; set; }
    public decimal IdMotCle { get; set; }



    public virtual  Notice Notice { get; set; } = null!;
    public virtual  MotsCle MotsCle { get; set; } = null!;


}