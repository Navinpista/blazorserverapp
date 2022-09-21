using System;
using System.Collections.Generic;

namespace ROI_BI_Lib.Models
{
    public partial class UserLogin
    {
        public UserLogin()
        {
            LoginAudits = new HashSet<LoginAudit>();
        }

        public int UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public bool? IsActive { get; set; }

        public virtual ICollection<LoginAudit> LoginAudits { get; set; }
    }
}
