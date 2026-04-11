    using System;
    using System.Collections.Generic;

    namespace LibraryManagement.Shared.Models;

    public partial class NoticeTerme
    {
        public decimal IdTerme { get; set; }

        public decimal IdNotice { get; set; }

        public decimal PoidsTerme { get; set; }

        public virtual Notice Notice { get; set; } = null!;

        public virtual Terme Terme { get; set; } = null!;
    }
