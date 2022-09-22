using Microsoft.EntityFrameworkCore;
using ROI_BI_Lib.Models;

namespace ROI_BI_Lib.Data
{
    public class ROIReportService
    {
        public ROIBIContext DbContext { get; set; }
        public ROIReportService(ROIBIContext dbContext)
        {
            DbContext = dbContext;
        }
        public async Task<Report> GetROIReportdetails(string reportId)
        {

            if(reportId == "0")
            {
                return null;
            }

            return await DbContext.Reports.Include(p=> p.Tenant).Where(x => x.ReportGuid == reportId).FirstAsync();
        }
    }
}
