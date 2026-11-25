// Name: Jeassen Andrew Silitonga
// NIM: 2481037
// Course: Framework .NET Programming

using Microsoft.EntityFrameworkCore;
using StudentInformationSystem.Models;

namespace StudentInformationSystem.Data
{
    // Inserts sample students when the table is empty.
    public static class StudentSeeder
    {
        public static async Task SeedAsync(ApplicationDbContext db)
        {
            // Skip seeding if data already exists.
            if (await db.Students.AnyAsync()) return;

            db.Students.AddRange(
                new Student
                {
                    NIM = "2481037",
                    Name = "Jeassen Andrew Silitonga",
                    Major = "Informatics Engineering",
                    Semester = 5,
                    GPA = 3.75
                },
                new Student
                {
                    NIM = "2481036",
                    Name = "Christoper Hiero Barus",
                    Major = "Informatics Engineering",
                    Semester = 5,
                    GPA = 3.70
                },
                new Student
                {
                    NIM = "2481040",
                    Name = "Jeremy Nababan",
                    Major = "Informatics Engineering",
                    Semester = 5,
                    GPA = 3.70
                }
            );

            await db.SaveChangesAsync();
        }
    }
}