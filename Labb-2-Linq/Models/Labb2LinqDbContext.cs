using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Labb_2_Linq.Models
{
    public class Labb2LinqDbContext : DbContext
    {
        public DbSet<Lärare> _Lärare { get; set; }
        public DbSet<Kurs> _Kurs { get; set; }
        public DbSet<Student> _Student { get; set; }
        public DbSet<Ämne> _Ämne { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source = LUKKAN-DESKTOP; Initial Catalog = Labb-2-Linq; Integrated Security = True;");
        }
       
    }
}
