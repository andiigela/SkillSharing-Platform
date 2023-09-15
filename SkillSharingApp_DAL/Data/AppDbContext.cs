using Microsoft.EntityFrameworkCore;
using SkillSharingApp_DAL.DAL_DTOs.ApplicationUser;
using SkillSharingApp_DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkillSharingApp_DAL.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
        public DbSet<Tutorial> Tutorials { get; set; }
        public DbSet<Lesson> Lessons { get; set; }
        public DbSet<Workshop> Workshops { get; set; }
        public DbSet<Attendance> Attendances { get; set; }
        public DbSet<CreateApplicationUserDto_DAL> CreateApplicationUserDto_DAL { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Attendance>()
                .HasKey(a => new { a.CreateApplicationUserDto_DALId, a.WorkshopId });
        }
    }
}
