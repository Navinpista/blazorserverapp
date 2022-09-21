using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ROI_BI_Lib.Models.Dto
{
    public class MenuDTO
    {
        public int MenuId { get; set; }
        public int? ParentMenuId { get; set; }
        public string MenuName { get; set; }
        public string Description { get; set; }
        public bool? IsGroup { get; set; }
        public bool? Status { get; set; }
        public string Icon { get; set; }
        public int ReportId { get; set; }
        public string ReportName { get; set; }
        public string ReportGuid { get; set; }
    }
}
