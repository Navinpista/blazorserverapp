using System;
using System.Collections.Generic;

namespace ROI_BI_Lib.Models
{
    public partial class ReportAudit
    {
        public int ReportAudit1 { get; set; }
        public string LoginSessionId { get; set; }
        public string ReportId { get; set; }
        public DateTime? AuditTime { get; set; }
        public string LoginSource { get; set; }
    }
}
