using Microsoft.EntityFrameworkCore;
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

    }
}
