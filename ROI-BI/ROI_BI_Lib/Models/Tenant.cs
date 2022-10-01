using System;
using System.Collections.Generic;

namespace ROI_BI_Lib.Models
{
    public partial class Tenant
    {
        public Tenant()
        {
            Reports = new HashSet<Report>();
        }

        public int TenantId { get; set; }
        public string TenantGuid { get; set; }
        public string ClientGuid { get; set; }
        public string ClientSecret { get; set; }
        public string TenantName { get; set; }

        public virtual ICollection<Report> Reports { get; set; }
    }
}
