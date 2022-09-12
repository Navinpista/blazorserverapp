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
        public async Task<Roireport> GetROIReportdetails(string reportId)
        {
            return await DbContext.Roireports.Where(x => x.ReportId == reportId).FirstAsync();
        }
    }
}
