using System;
using System.Collections.Generic;

namespace ROI_BI_Lib.Models
{
    public partial class Roireport
    {
        public int Id { get; set; }
        public string ReportName { get; set; }
        public string TenantId { get; set; }
        public string ClientId { get; set; }
        public string ClientSecret { get; set; }
        public string WorkspaceId { get; set; }
        public string ReportId { get; set; }
    }
}
