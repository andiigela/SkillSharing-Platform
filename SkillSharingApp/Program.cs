using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using SkillSharingApp.Data;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using SkillSharingApp_BAL.Services;
using SkillSharingApp_DAL.Contracts;
using SkillSharingApp_DAL.Data;
using SkillSharingApp_DAL.Models;
using SkillSharingApp_DAL.Repositories;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.Google;
using SkillSharingApp_BAL.MappingProfiles;
using SkillSharingApp.Models;
using SkillSharingApp_DAL.DAL_DTOs.ApplicationUser;
using SkillSharingApp_DAL.DAL_DTOs.ApplicationUser;
using SkillSharingApp.Models;
using SkillSharingApp.BLL.Services;
using SkillSharingApp.DAL.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");


builder.Services.AddScoped<CommentRepository>();
builder.Services.AddScoped<ICommentRepository>(provider => provider.GetService<CommentRepository>());
builder.Services.AddScoped<CommentService>();
builder.Services.AddScoped<ICommentService>(provider => provider.GetService<CommentService>());

builder.Services.AddScoped<ILessonRepository<Lesson>, LessonRepository>();
builder.Services.AddScoped<IServiceLesson, ServiceLesson>();
builder.Services.AddScoped<ITutorialRepository, TutorialRepository>();
builder.Services.AddScoped<ITutorialService, TutorialService>();

builder.Services.AddAutoMapper(typeof(SkillSharingApp.RequestHelpers.MappingProfiles).Assembly);
builder.Services.AddAutoMapper(typeof(SkillSharingApp.RequestHelpers.MappingProfiles).Assembly);
builder.Services.AddAutoMapper(typeof(TutorialProfile).Assembly);


builder.Services.AddScoped<IWorkshopRepository<Workshop>, WorkshopRepository>();
builder.Services.AddScoped<IServiceWorkshop, ServiceWorkshop>();
builder.Services.AddScoped<IServiceUploadImage, ServiceUploadImage>();
builder.Services.AddScoped<IServiceApplicationUser, ServiceApplicationUser>();
builder.Services.AddScoped<IApplicationUserRepository<CreateApplicationUserDto_DAL>, ApplicationUserRepository>();
builder.Services.AddScoped<IServiceAttendance, ServiceAttendance>();
builder.Services.AddScoped<IAttendanceRepository<Attendance>, AttendanceRepository>();


builder.Services.AddDbContext<AppDbContext>(options =>
  options.UseSqlServer(connectionString, b => b.MigrationsAssembly("SkillSharingApp")));
builder.Services.AddDbContext<ApplicationDbContext>(options =>
  options.UseSqlServer(connectionString));
builder.Services.AddDatabaseDeveloperPageExceptionFilter();
builder.Services.AddDefaultIdentity<ApplicationUser>(options => options.SignIn.RequireConfirmedAccount = true)
  .AddRoles<IdentityRole>()
  .AddUserManager<ApplicationManager>()
  .AddEntityFrameworkStores<ApplicationDbContext>();
builder.Services.AddControllersWithViews();
builder.Services.AddScoped<RoleManager<IdentityRole>>();
builder.Services.AddAuthentication()
  .AddGoogle(g =>
  {
      g.ClientId = "635903647141-rlbub16bpd0tgo3g5t3emen7vhgeorq8.apps.googleusercontent.com";
      g.ClientSecret = "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";
  });

builder.Services.AddAuthorization();


builder.Services.AddRazorPages();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
}
else
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute(
      name: "default",
      pattern: "{controller=Home}/{action=Index}/{id?}");

    endpoints.MapControllerRoute(
      name: "tutorial",
      pattern: "{controller=Tutorial}/{action=Index}/{id?}");

    endpoints.MapControllerRoute(
      name: "default",
      pattern: "{controller=Roles}/{action=Index}");

    endpoints.MapControllerRoute(
      name: "default",
      pattern: "{controller=Roles}/{action=Create}");

    endpoints.MapControllerRoute(
      name: "default",
      pattern: "{controller=Roles}/{action=Delete}");
        name: "default",
        pattern: "{controller=RolesController}/{action=Index}");
});
app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute(
        name: "default",
        pattern: "{controller=RolesController}/{action=Create}");
});
app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute(
        name: "default",
        pattern: "{controller=RolesController}/{action=Delete}");
});



app.MapRazorPages();

app.Run();
