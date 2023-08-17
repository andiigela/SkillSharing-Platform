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

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");


builder.Services.AddScoped<ILessonRepository<Lesson>, LessonRepository>();
builder.Services.AddScoped<IServiceLesson, ServiceLesson>();


builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(connectionString, b => b.MigrationsAssembly("SkillSharingApp")));

builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(connectionString));
builder.Services.AddDatabaseDeveloperPageExceptionFilter();

builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddRoles<IdentityRole>()
    .AddEntityFrameworkStores<ApplicationDbContext>();

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
        pattern: "{controller=Roles}/{action=Index}");
});
app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute(
        name: "default",
        pattern: "{controller=Roles}/{action=Create}");
});
app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute(
        name: "default",
        pattern: "{controller=Roles}/{action=Delete}");
});



app.MapRazorPages();

app.Run();
