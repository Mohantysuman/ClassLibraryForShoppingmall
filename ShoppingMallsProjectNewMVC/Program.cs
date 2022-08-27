using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using ShoppingMallsProjectNewMVC.Areas.Identity.Data;
using ShoppingMallsProjectNewMVC.Data;
using ShoppingMallsProjectNewMVC.Models;

var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("ShoppingMallsProjectNewMVCContextConnection") ?? throw new InvalidOperationException("Connection string 'ShoppingMallsProjectNewMVCContextConnection' not found.");

builder.Services.AddDbContext<ShoppingMallsProjectNewMVCContext>(options =>
   options.UseSqlServer(connectionString));
builder.Services.AddDbContext<ShoppingAdminDbContext>(options =>
    options.UseSqlServer(connectionString));


//builder.Services.AddDefaultIdentity<ShoppingMallsProjectNewMVCUser>(options => options.SignIn.RequireConfirmedAccount = true)
//AddEntityFrameworkStores<ShoppingMallsProjectNewMVCContext>();
builder.Services.AddIdentity<ShoppingMallsProjectNewMVCUser, IdentityRole>(options => options.SignIn.RequireConfirmedAccount = false)
    .AddDefaultUI().AddEntityFrameworkStores<ShoppingMallsProjectNewMVCContext>();
builder.Services.AddAutoMapper(typeof(Program));
builder.Services.AddScoped<ShoppingAdminDbContext>();
// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
app.UseAuthentication();;

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
app.MapRazorPages();
app.Run();
