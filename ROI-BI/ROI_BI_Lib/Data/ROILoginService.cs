using Microsoft.EntityFrameworkCore;
using ROI_BI_Lib.Models;
using ROI_BI_Lib.Models.Dto;
using System.Data.SqlTypes;
using System.Reflection.Metadata.Ecma335;
using Microsoft.AspNetCore.Components.Server.ProtectedBrowserStorage;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.AspNetCore.Http;

namespace ROI_BI_Lib.Data
{
    public class ROILoginService
    {
        public ROIBIContext DbContext { get; set; }
        public ProtectedSessionStorage RoiSession { get; set; }
        
        public ProtectedLocalStorage roilocalstore { get; set; }

        public ROILoginService(ROIBIContext dbContext, ProtectedSessionStorage storage, ProtectedLocalStorage roilocalstore)
        {
            DbContext = dbContext;
            RoiSession = storage;
            this.roilocalstore = roilocalstore;
        }
        public async Task<bool> SignIn(LoginDTO login)
        {
            await RoiSession.SetAsync("LoginStatus", "Authorized");
            await roilocalstore.SetAsync("LoginStatus", "Authorized");
            return await Task.Run(() => true);
            //return await DbContext.Roimenus.ToListAsync();
        }
    }
}
