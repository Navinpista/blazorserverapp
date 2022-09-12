using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Server.ProtectedBrowserStorage;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.EntityFrameworkCore;
using ROI_BI_Lib.Data;
using ROI_BI_Lib.Helpers;

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

app.Run();
