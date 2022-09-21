using Microsoft.AspNetCore.Components.Server.ProtectedBrowserStorage;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using ROI_BI_Lib.Models.Dto;
using System.Text.Json;

namespace ROI_BI_Lib.Data
{
    public class ROIMenuService
    {
        public ROIBIContext DbContext { get; set; }
        public ProtectedSessionStorage RoiSession { get; set; }
        public ROIMenuService(ROIBIContext dbContext, ProtectedSessionStorage storage)
        {
            DbContext = dbContext;
            RoiSession = storage;
        }
        public async Task<IEnumerable<MenuDTO>> GetROIMenu()
        {
            var menuJson = await RoiSession.GetAsync<string>("UserMenu");
            return null;// await JsonSerializer.DeserializeAsync<Menu>(menuJson);
        }
    }
}
