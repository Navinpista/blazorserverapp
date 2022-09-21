using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using ROI_BI_Lib.Models.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ROI_BI_Lib.Data
{
    public partial class ROIBIContext
    {
        public virtual DbSet<MenuDTO> MenusDTO { get; set; }

   }
}
