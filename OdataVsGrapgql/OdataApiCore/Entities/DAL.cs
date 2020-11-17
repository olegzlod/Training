using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OdataApiCore.Entities
{
    public class DAL : DbContext
    {

        public DAL(DbContextOptions<DAL> options) : base(options)
        {

        }

        public DbSet<Student> Students { get; set; }

        //remove pluralized uncomment this
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Student>().ToTable("Student");
            modelBuilder.Entity<Course>().ToTable("Course");
            //todo check ownsmany
            modelBuilder.Entity<StudentCourse>().ToTable("StudentCourse");
        }
    }
}
