using ROI_BI_Lib;
using ROI_BI_Lib.Data;
using Microsoft.AspNetCore.Components.WebView.WindowsForms;
using Microsoft.Extensions.DependencyInjection;
using System.Configuration;
using Microsoft.EntityFrameworkCore;
using ROI_BI_Lib.Pages.BIReport;
using Microsoft.Extensions.Configuration;
using ROI_BI_Lib.Helpers;
using System.Net.NetworkInformation;
using Microsoft.Web.WebView2.WinForms;
using Microsoft.JSInterop;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.AspNetCore.Http;
using MudBlazor.Services;

namespace ROI_BI_Win
{
    public partial class Form1 : System.Windows.Forms.Form
    {
        private static RoiDto _roiDto = new();

        public Form1()
        {
            try
            {
                //MessageBox.Show("app started");
                var strConnection = Properties.Settings.Default.ROIBIDB;
                //MessageBox.Show(strConnection);

                var lstService = new ServiceCollection();

                //lstService.WebHost.UseWebRoot("wwwroot").UseStaticWebAssets();

                //lstService.AddBlazorWebView();
                lstService.AddWindowsFormsBlazorWebView();
                lstService.AddBlazorWebViewDeveloperTools();

                //serviceCollection.AddSingleton<ROIBIContext>();
                // lstService.AddSingleton<Microsoft.AspNetCore.Components.Server.ProtectedBrowserStorage>();
                //serviceCollection.AddSingleton<IConfiguration>();
                lstService.AddSingleton<ROIReportService>();
                lstService.AddSingleton<ROIMenuService>();
                lstService.AddSingleton<ROIBIReport>();
                lstService.AddScoped<ROILoginService>();
                lstService.AddScoped<ROIAdminService>();
                lstService.AddScoped<HttpClient>();
                lstService.AddSingleton<RoiDto>(_roiDto);
                lstService.AddDataProtection();
                lstService.AddMudServices();

                lstService.AddScoped<Microsoft.AspNetCore.Components.Server.ProtectedBrowserStorage.ProtectedSessionStorage>();
                lstService.AddScoped<Microsoft.AspNetCore.Components.Server.ProtectedBrowserStorage.ProtectedLocalStorage>();


                //lstService.AddScoped<IJSRuntime>();
                //lstService.AddScoped<IDataProtectionProvider>();

                lstService.AddDbContext<ROIBIContext>(options =>
                {
                    options.UseSqlServer(strConnection);
                }, ServiceLifetime.Singleton);


                //lstService.AddSmart();

                InitializeComponent();

                blazorWebView1.HostPage = @"wwwroot\index.html";
                //blazorWebView1.HostPage.
                blazorWebView1.Services = lstService.BuildServiceProvider();
                blazorWebView1.RootComponents.Add<App>("#app");

                var userData = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData), "ROI_BI_Win");
                Directory.CreateDirectory(userData);
                var creationProperties = new CoreWebView2CreationProperties()
                {
                    UserDataFolder = userData
                };
                blazorWebView1.WebView.CreationProperties = creationProperties;


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                MessageBox.Show(ex.StackTrace);
                throw;
            }
            //blazorWebView1.WebView.CoreWebView2.;// .getSettings().setJavaScriptEnabled(true);

            //string html = await blazorWebView1.InvokeScriptAsync("eval", new string[] { "document.documentElement.outerHTML;" });
            //var text = html;

        }

        private void btnGetReport_Click(object sender, EventArgs e)
        {
            _roiDto.DtoCommand = "TESTING123";
        }
    }
}