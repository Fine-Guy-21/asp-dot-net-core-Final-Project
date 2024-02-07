using Microsoft.AspNetCore.Identity;
using Fine_FreeLancing_Website.Models;
using Microsoft.EntityFrameworkCore;
using Fine_FreeLancing_Website.MyMiddleware;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();

var ConnString = builder.Configuration.GetConnectionString("MySQlConn");

builder.Services.AddScoped <IJobRepository, JobRepository>();

builder.Services.AddDbContext<MyDbContext>(options =>
{
    options.UseMySql(ConnString, ServerVersion.AutoDetect(ConnString));
});

builder.Services.AddIdentity<User, IdentityRole>().
    AddEntityFrameworkStores<MyDbContext>().AddDefaultTokenProviders();
var app = builder.Build(); 

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseMiddleware<Inform>();

app.UseStaticFiles();
app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();



app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
