using System;
using System.Collections.Generic;

namespace ROI_BI_Lib.Models
{
    public partial class Report
    {
        public Report()
        {
            MenuReports = new HashSet<MenuReport>();
            ReportAccesses = new HashSet<ReportAccess>();
        }

        public int ReportId { get; set; }
        public string ReportName { get; set; }
        public string ReportGuid { get; set; }
        public bool? IsDashboard { get; set; }
        public string WorkspaceGuid { get; set; }
        public int TenantId { get; set; }

        public virtual Tenant Tenant { get; set; }
        public virtual ICollection<MenuReport> MenuReports { get; set; }
        public virtual ICollection<ReportAccess> ReportAccesses { get; set; }
    }
}
