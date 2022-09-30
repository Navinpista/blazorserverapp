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
        public UserLogin GetUser(int id)
        {
            return DbContext.UserLogins.FirstOrDefault(x => x.UserId == id);
        }
        

        public async Task<List<Menu>> GetAllMenu()
        {
            return await DbContext.Menus.ToListAsync();
        }
        public async Task<List<Report>> GetAllReport()
        {
            return await DbContext.Reports.ToListAsync();
        }
        public async Task<List<ReportAccess>> GetAllAccess()
        {
            return await DbContext.ReportAccesses.ToListAsync();
        }
        

    }
}
