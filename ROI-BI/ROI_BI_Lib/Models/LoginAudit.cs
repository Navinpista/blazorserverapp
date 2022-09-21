using System;
using System.Collections.Generic;

namespace ROI_BI_Lib.Models
{
    public partial class LoginAudit
    {
        public int LoginAuditId { get; set; }
        public int? UserId { get; set; }
        public DateTime? LoginTime { get; set; }
        public DateTime? LogoutTime { get; set; }
        public bool? LoginStatus { get; set; }
        public string LoginMessage { get; set; }
        public string LoginSessionId { get; set; }

        public virtual UserLogin User { get; set; }
    }
}
