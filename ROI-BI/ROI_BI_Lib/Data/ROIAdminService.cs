using Microsoft.EntityFrameworkCore;
using ROI_BI_Lib.Models;

namespace ROI_BI_Lib.Data
{
    public class ROIAdminService
    {
        public ROIBIContext DbContext { get; set; }
        public ROIAdminService(ROIBIContext dbContext)
        {
            DbContext = dbContext;
        }
        public async Task<List<UserLogin>> GetAllUser()
        {
            return await DbContext.UserLogins.ToListAsync();
        }
    }
}
