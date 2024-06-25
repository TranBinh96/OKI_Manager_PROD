using Bulky.DataAccess.Data;
using Microsoft.EntityFrameworkCore;
using Production.DataAccess.Repository.IRespository;
using Production.DataAccess.Repository;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Microsoft.AspNetCore.Identity.UI.Services;
using Production.Utility;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services
    .AddControllersWithViews()
    .AddJsonOptions(options => options.JsonSerializerOptions.PropertyNamingPolicy = null);

builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(
    builder.Configuration.GetConnectionString("DefaultConnection")
    ));
builder.Services.AddCors(options =>
{
    options.AddPolicy("CorsApi",
        builder => builder.AllowAnyOrigin()
         .AllowAnyHeader()
         .AllowAnyMethod());
});

builder.Services.AddIdentity<IdentityUser,IdentityRole>().AddDefaultTokenProviders()
    .AddEntityFrameworkStores<ApplicationDbContext>();
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddSingleton<IEmailSender, EmailSender>();


builder.Services.AddRazorPages().AddRazorRuntimeCompilation();



var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();
app.UseCors("CorsApi");
app.UseRouting();
app.UseAuthentication();;

app.UseRouting();

app.MapRazorPages();

/*app.MapControllerRoute(
    name: "default",
    pattern: "{area=Customer}/{controller=DetailProduction}/{action=Index}/{id?}");
*/

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute(
       name: "default",
        pattern: "{area=Customer}/{controller=DetailProduction}/{action=Index}/{id?}");
});
app.Run();





