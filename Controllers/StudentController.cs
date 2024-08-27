using Microsoft.AspNetCore.Mvc;
using StudentSearchWebApp.Models;
using System;
using System.Linq;
using System.Text.Json;
using System.Text;
using System.Collections.Generic;

namespace StudentSearchWebApp.Controllers
{
    public class StudentController : Controller
    {
        private readonly StudentService _studentService;

        
        public StudentController(StudentService studentService)
        {
            _studentService = studentService;
        }

        public IActionResult Index(string searchTerm, int? minAge, int? maxAge, string sortBy, string sortOrder)
        {
            // Use the SearchStudents method to apply all filters and sorting
            var students = _studentService.SearchStudents(searchTerm, minAge, maxAge, sortBy, sortOrder);

            ViewBag.SearchTerm = searchTerm;
            ViewBag.MinAge = minAge;
            ViewBag.MaxAge = maxAge;
            ViewBag.SortBy = sortBy;
            ViewBag.SortOrder = sortOrder;

            return View(students);
        }

        public IActionResult ExportToJson()
        {
            var students = _studentService.GetAllStudents();
            var json = JsonSerializer.Serialize(students, new JsonSerializerOptions { WriteIndented = true });
            return File(Encoding.UTF8.GetBytes(json), "application/json", "students.json");
        }

        [HttpPost]
        public IActionResult AddStudent(string name, int age, string major)
        {
            var students = _studentService.GetAllStudents();
            int newId = students.Max(s => s.Id) + 1;

            Student newStudent = new Student
            {
                Id = newId,
                Name = name,
                Age = age,
                Major = major
            };

            students.Add(newStudent);
            return RedirectToAction("Index");
        }
    }
}
