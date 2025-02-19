using Editor.Model.Projects;
using Editor.Model.Users;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Editor.DBContext
{
    public class AppDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Project> Projects { get; set; }

        public AppDbContext() { }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=DESKTOP-G6U036E\\SQLEXPRESS;Database=Editor;Trusted_Connection=True;encrypt = false");
            //optionsBuilder.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=Editor;Trusted_Connection=True;encrypt = false");
        }
    }
}
