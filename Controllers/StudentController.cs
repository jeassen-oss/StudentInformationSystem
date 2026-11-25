// Name: Jeassen Andrew Silitonga
// NIM: 2481037
// Course: Framework .NET Programming

using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StudentInformationSystem.Data;

namespace StudentInformationSystem.Controllers
{
    // Handles requests for student web pages.
    public class StudentController : Controller
    {
        private readonly ApplicationDbContext _db;

        public StudentController(ApplicationDbContext db) => _db = db;

        // Displays a student profile.
        // Without nim: first student. With nim: the matching student.
        public async Task<IActionResult> Profile(string? nim)
        {
            var student = string.IsNullOrWhiteSpace(nim)
                ? await _db.Students.AsNoTracking().OrderBy(s => s.Id).FirstOrDefaultAsync()
                : await _db.Students.AsNoTracking().FirstOrDefaultAsync(s => s.NIM == nim);

            // Return 404 if no student is found.
            return student is null ? NotFound() : View(student);
        }
    }
}