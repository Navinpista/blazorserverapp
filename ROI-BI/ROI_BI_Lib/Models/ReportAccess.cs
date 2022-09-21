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
    }
}
