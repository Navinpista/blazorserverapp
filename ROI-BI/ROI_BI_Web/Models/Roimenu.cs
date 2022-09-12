using System;
using System.Collections.Generic;

namespace ROIBIApp.Models
{
    public partial class Roimenu
    {
        public int MenuId { get; set; }
        public int ParentMenuId { get; set; }
        public string? MenuName { get; set; }
        public string? Description { get; set; }
        public string? NavigateUrl { get; set; }
        public string? Css { get; set; }
        public int? Status { get; set; }
        public string? PageName { get; set; }
        public string? IconName { get; set; }
    }
}
