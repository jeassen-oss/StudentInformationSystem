// Name: Jeassen Andrew Silitonga
// NIM: 2481037
// Course: Framework .NET Programming

using Microsoft.EntityFrameworkCore;
using StudentInformationSystem.Models;

namespace StudentInformationSystem.Data
{
    // Connects the application to the MySQL database.
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options) { }

        // Represents the Students table.
        public DbSet<Student> Students => Set<Student>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Student>(entity =>
            {
                entity.HasKey(s => s.Id);
                entity.HasIndex(s => s.NIM).IsUnique();
                entity.Property(s => s.NIM).HasMaxLength(20).IsRequired();
                entity.Property(s => s.Name).HasMaxLength(120).IsRequired();
                entity.Property(s => s.Major).HasMaxLength(100).IsRequired();
            });
        }
    }
}