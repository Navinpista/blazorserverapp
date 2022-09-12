using Microsoft.EntityFrameworkCore;
using ROI_BI_Lib.Models;
using ROI_BI_Lib.Models.Dto;
using System.Data.SqlTypes;
using System.Reflection.Metadata.Ecma335;

namespace ROI_BI_Lib.Data
{
    public class ROILoginService
    {
        public ROIBIContext DbContext { get; set; }
        public ROILoginService(ROIBIContext dbContext)
        {
            DbContext = dbContext;
        }
        public async Task<bool> SignIn(LoginDTO login)
        {
            return await Task.Run(() => true);
            //return await DbContext.Roimenus.ToListAsync();
        }
    }
}
