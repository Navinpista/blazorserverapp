using System;
using System.Collections.Generic;

namespace ROI_BI_Lib.Models
{
    public partial class Menu
    {
        public Menu()
        {
            MenuReports = new HashSet<MenuReport>();
        }

        public int MenuId { get; set; }
        public int? ParentMenuId { get; set; }
        public string MenuName { get; set; }
        public string Description { get; set; }
        public bool? IsGroup { get; set; }
        public bool? Status { get; set; }
        public string Icon { get; set; }

        public virtual ICollection<MenuReport> MenuReports { get; set; }
    }
}
