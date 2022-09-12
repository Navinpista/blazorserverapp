using Microsoft.EntityFrameworkCore;
using ROIBIApp.Models;

namespace ROIBIApp.Data
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
