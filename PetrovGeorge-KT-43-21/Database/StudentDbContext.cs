using Microsoft.EntityFrameworkCore;
using PetrovGeorge_KT_43_21.Database.Configurations;
using PetrovGeorge_KT_43_21.Models;

namespace PetrovGeorge_KT_43_21.Database
{
    public class StudentDbContext : DbContext
    {
        DbSet<Student> Students {  get; set; }
        DbSet<Group> Groups { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new StudentConfiguration());
            modelBuilder.ApplyConfiguration(new GroupConfiguration());
        }
        public StudentDbContext(DbContextOptions<StudentDbContext> options) : base(options) 
        { 
        }
    }
}
