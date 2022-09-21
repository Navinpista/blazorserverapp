using Microsoft.EntityFrameworkCore;
using ROI_BI_Lib.Models.Dto;
using System.Data.SqlTypes;
using System.Reflection.Metadata.Ecma335;
using Microsoft.AspNetCore.Components.Server.ProtectedBrowserStorage;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.AspNetCore.Http;
using System.Text.Json;
using ROI_BI_Lib.Models;
using System.Data.Common;

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
            List<MenuDTO> lstUserMenu = default;
            var userlogin = DbContext.UserLogins.Where(x => x.UserName == login.Username && x.Password == login.Password).FirstOrDefault();

            if(userlogin is not null)
            {
                await RoiSession.SetAsync("LoginStatus", "Authorized");
                DbContext.LoginAudits.Add(new Models.LoginAudit()
                {
                    LoginSessionId = Guid.NewGuid().ToString(),
                    UserId = userlogin.UserId,
                    LoginMessage="Authorized",
                    LoginTime=DateTime.Now,
                    LoginStatus = true
                });
                DbContext.SaveChanges();

                var lstMenu = DbContext.MenusDTO.FromSqlRaw("EXEC GetMenuByUser {0}", userlogin.UserId)?.ToList();
                var lstParentMenu = DbContext.Menus.Where(x => lstMenu.Select(y => y.ParentMenuId).Contains(x.MenuId))?.ToList();

                if (lstMenu?.Count > 0)
                {
                    lstUserMenu = lstMenu;

                    if (lstParentMenu?.Count > 0)
                    {
                        foreach(var menu in lstParentMenu)
                        {
                            lstUserMenu.Add(new MenuDTO()
                            {
                                Description = menu.Description,
                                Icon = menu.Icon,
                                IsGroup = menu.IsGroup,
                                MenuId = menu.MenuId,
                                MenuName = menu.MenuName
                            });
                        }
                    }
                }
                
                await RoiSession.SetAsync("UserMenu", JsonSerializer.Serialize(lstUserMenu));

            }
            else
            {
                await RoiSession.SetAsync("LoginStatus", "UnAuthorized");
            }

           
            //await roilocalstore.SetAsync("LoginStatus", "Authorized");
            return await Task.Run(() => true);
            //return await DbContext.Roimenus.ToListAsync();
        }
    }
}
