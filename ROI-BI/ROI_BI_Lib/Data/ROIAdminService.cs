using Microsoft.EntityFrameworkCore;
using ROI_BI_Lib.Models;
using ROI_BI_Lib.Models.Dto;
using System.Security.Cryptography.X509Certificates;

namespace ROI_BI_Lib.Data
{
    public class ROIAdminService
    {
        public ROIBIContext DbContext { get; set; }
        public ROIAdminService(ROIBIContext dbContext)
        {
            DbContext = dbContext;
        }


        public async Task<List<Tenant>> GetAllTenant()
        {
            return await DbContext.Tenants.ToListAsync();
        }
        public async Task<List<UserLogin>> GetAllUser()
        {
            return await DbContext.UserLogins.ToListAsync();
        }
        public UserLogin GetUser(int id)
        {
            return DbContext.UserLogins.FirstOrDefault(x => x.UserId == id);
        }
        public Menu GetMenu(int id)
        {
            return DbContext.Menus.FirstOrDefault(x => x.MenuId == id);
        }
        public Report GetReport(int id)
        {
            return DbContext.Reports.Where(x => x.ReportId == id).Include(x => x.Tenant).FirstOrDefault();
        }
        public ReportAccess GetReportAccess(int id)
        {
            return DbContext.ReportAccesses.Include(x => x.User).FirstOrDefault(x => x.ReportAccessId == id);
        }


        public void SaveUser(UserLogin user)
        {
            if (user.UserId > 0)
            {
                DbContext.UserLogins.Update(user);
            }
            else
            {
                DbContext.UserLogins.AddAsync(user);
            }
            DbContext.SaveChanges();
        }

        public void SaveMenu(Menu menu)
        {
            if (menu.MenuId > 0)
            {
                DbContext.Menus.Update(menu);
            }
            else
            {
                DbContext.Menus.AddAsync(menu);
            }
            DbContext.SaveChanges();
        }

        public void SaveReport(Report report)
        {
            if (report.ReportId > 0)
            {
                DbContext.Reports.Update(report);
            }
            else
            {
                DbContext.Reports.AddAsync(report);
            }
            DbContext.SaveChanges();
        }

        public void SaveReportAccess(ReportAccess reportAccess)
        {
            if (reportAccess.ReportAccessId > 0)
            {
                DbContext.ReportAccesses.Update(reportAccess);
            }
            else
            {
                DbContext.ReportAccesses.AddAsync(reportAccess);
            }
            DbContext.SaveChanges();
        }

        public void SaveUserReportAccess(List<UserAccessDTO> userreportAccess)
        {

            var accessUser = userreportAccess.Where(x => x.HasAccess == "TRUE").Select(x => new ReportAccess()
            {
                //ReportAccessId = x.ReportAccessId,
                ReportId = x.ReportId,
                UserId = x.UserId,
                IsActive = true
            });

            DbContext.ReportAccesses.RemoveRange
                (DbContext.ReportAccesses.Where
                (x => userreportAccess.Select(y => y.ReportAccessId).Contains(x.ReportAccessId)));

            //DbContext.Database.ExecuteSqlRaw("TRUNCATE TABLE [ReportAccess]");
            DbContext.ReportAccesses.AddRange(accessUser);
            DbContext.SaveChanges();
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
            return await DbContext.ReportAccesses.Include(x => x.User).Include(x => x.Report).ToListAsync();
        }
        public List<UserAccessDTO> GetAccessByReport(int reportId)
        {
            var access = DbContext.ReportAccesses.Include(x => x.Report).Include(x => x.User).Where(x => x.ReportId == reportId)
                .Select(x => new UserAccessDTO()
                {
                    ReportAccessId = x.ReportAccessId,
                    FirstName = x.User.FirstName,
                    LastName = x.User.LastName,
                    ReportId = x.Report.ReportId,
                    UserId = x.UserId,
                    UserName = x.User.UserName,
                    HasAccess = "TRUE"
                }).ToList();


            var inaccess = DbContext.UserLogins.Where(x => !access.Select(y => y.UserId).ToList().Contains(x.UserId))
            .Select(x => new UserAccessDTO()
            {
                FirstName = x.FirstName,
                LastName = x.LastName,
                ReportId = 0,
                UserId = x.UserId,
                UserName = x.UserName,
                HasAccess = "FALSE"
            }).ToList();

            access.AddRange(inaccess);
            return access;

        }


    }
}
