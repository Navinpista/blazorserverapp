using System;
using System.Collections.Generic;

namespace ROI_BI_Lib.Models
{
    public partial class MenuReport
    {
        public int MenuReportId { get; set; }
        public int MenuId { get; set; }
        public int ReportId { get; set; }

        public virtual Menu Menu { get; set; }
        public virtual Report Report { get; set; }
    }
}
