using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ROI_BI_Lib.Models.Dto
{
    public class UserAccessDTO
    {
        public int ReportAccessId { get; set; }
        public int UserId { get; set; }
        public int ReportId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string HasAccess { get; set; }
    }
}
