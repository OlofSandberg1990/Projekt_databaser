using Microsoft.EntityFrameworkCore;
using Projekt_Databaser.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekt_Databaser.Data
{
    internal class ProjectSchoolDbContext :DbContext
    {
        public DbSet<Class> Classes { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Mark> Marks { get; set; }
        public DbSet<MarkMeaning> MarksMeanings { get; set;}
        public DbSet<Role> Roles { get; set; }
        public DbSet <Student> Students { get; set; }

        public DbSet<Department> Departments { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data source=OLOFSPC; Initial Catalog=ProjectCodeFirst_SchoolDb; Integrated Security=True; TrustServerCertificate=True;");
        }
    }
}
