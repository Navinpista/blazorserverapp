using Microsoft.EntityFrameworkCore;
using ROI_BI_Lib.Models;

namespace ROI_BI_Lib.Data
{
    public class ROIMenuService
    {
        public ROIBIContext DbContext { get; set; }
        public ROIMenuService(ROIBIContext dbContext)
        {
            DbContext = dbContext;
        }
        public async Task<IEnumerable<Roimenu>> GetROIMenu()
        {
            return await DbContext.Roimenus.ToListAsync();
        }
    }
}
