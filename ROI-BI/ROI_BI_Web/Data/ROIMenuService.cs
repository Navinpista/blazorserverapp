using Microsoft.EntityFrameworkCore;
using ROIBIApp.Models;

namespace ROIBIApp.Data
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
