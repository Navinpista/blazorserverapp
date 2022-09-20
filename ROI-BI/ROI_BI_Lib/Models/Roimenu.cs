using System;
using System.Collections.Generic;

namespace ROI_BI_Lib.Models
{
    public partial class Roimenu
    {
        public int MenuId { get; set; }
        public int ParentMenuId { get; set; }
        public string MenuName { get; set; }
        public string Description { get; set; }
        public string NavigateUrl { get; set; }
        public int? Status { get; set; }
        public string IconName { get; set; }
        public bool IsGroup { get; set; }
        public string GroupName { get; set; }
    }
}
