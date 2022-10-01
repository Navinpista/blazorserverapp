using System;
using System.Collections.Generic;

namespace ROI_BI_Lib.Models
{
    public partial class ReportAccess
    {
        public int ReportAccessId { get; set; }
        public int ReportId { get; set; }
        public int UserId { get; set; }
        public bool? IsActive { get; set; }

        public virtual Report Report { get; set; }
        public virtual UserLogin User { get; set; }
    }
}
