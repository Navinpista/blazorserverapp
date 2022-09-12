using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ROI_BI_Lib.Models.Dto;
using ROI_BI_Lib.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ROI_BI_Lib.Models.BindingModel
{
    public class LoginBindingModel : PageModel
    {
        [BindProperty]
        public LoginDTO Login { get; set; }
    }
}
