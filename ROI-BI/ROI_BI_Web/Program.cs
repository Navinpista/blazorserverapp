using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Server.ProtectedBrowserStorage;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.EntityFrameworkCore;
using ROI_BI_Lib.Data;
using ROI_BI_Lib.Helpers;
using MudBlazor.Services;
using Microsoft.Extensions.Hosting;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System;

var builder = WebApplication.CreateBuilder(args);
builder.WebHost.UseWebRoot("wwwroot").UseStaticWebAssets();

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddDataProtection();
builder.Services.AddServerSideBlazor();
builder.Services.AddScoped<ProtectedSessionStorage>();
builder.Services.AddScoped<ProtectedLocalStorage>();
builder.Services.AddScoped<ROIMenuService>();
builder.Services.AddScoped<ROIReportService>();
builder.Services.AddScoped<ROILoginService>();
builder.Services.AddScoped<RoiDto>();
builder.Services.AddMudServices();

builder.WebHost.UseKestrel(x => x.ListenAnyIP(6969));

var Configuration = builder.Configuration;//.GetSection("ConnectionStrings");

builder.Services.AddDbContext<ROIBIContext>(options =>
{
    options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"));
}, ServiceLifetime.Singleton);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
}


app.UseStaticFiles();

app.UseRouting();

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

//app.Start();


if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
{
    Process.Start(new ProcessStartInfo("http://localhost:6969/") { UseShellExecute = true });
}
else if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
{
    Process.Start("xdg-open", "http://localhost:6969/");
}
else if (RuntimeInformation.IsOSPlatform(OSPlatform.OSX))
{
    Process.Start("open", "http://localhost:6969/");
}
else
{
    // throw 
}
//OpenBrowser("http://localhost:6969/");

app.Run();


