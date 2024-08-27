using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using Microsoft.AspNetCore.Hosting;

namespace StudentSearchWebApp.Models
{
    public class StudentService
    {
        private readonly IWebHostEnvironment _environment;
        private List<Student> students;

        public StudentService(IWebHostEnvironment environment)
        {
            _environment = environment;
            students = new List<Student>();

            // Load in-memory students
            LoadInMemoryStudents();

            // Load students from JSON and combine
            LoadStudentsFromJson();
        }

        private void LoadInMemoryStudents()
        {
            // Initial in-memory student list
            students.AddRange(new List<Student>
            {
                new Student { Id = 1, Name = "Alice", Age = 20, Major = "Computer Science" },
                new Student { Id = 2, Name = "Bob", Age = 22, Major = "Mathematics" },
                new Student { Id = 3, Name = "Charlie", Age = 21, Major = "Physics" },
                new Student { Id = 4, Name = "David", Age = 19, Major = "Engineering" },
                new Student { Id = 5, Name = "Eva", Age = 23, Major = "Biology" },
                new Student { Id = 6, Name = "Frank", Age = 18, Major = "Computer Science" },
                new Student { Id = 7, Name = "Grace", Age = 24, Major = "Chemistry" },
                new Student { Id = 8, Name = "Henry", Age = 20, Major = "Mathematics" },
                new Student { Id = 9, Name = "Ivy", Age = 21, Major = "Physics" },
                new Student { Id = 10, Name = "Jack", Age = 22, Major = "Engineering" },
                new Student { Id = 11, Name = "Kate", Age = 20, Major = "Biology" },
                new Student { Id = 12, Name = "Leo", Age = 19, Major = "Computer Science" },
                new Student { Id = 13, Name = "Mia", Age = 22, Major = "Mathematics" },
                new Student { Id = 14, Name = "Noah", Age = 23, Major = "Physics" },
                new Student { Id = 15, Name = "Olivia", Age = 18, Major = "Engineering" },
                new Student { Id = 16, Name = "Paul", Age = 21, Major = "Chemistry" }
            });
        }

        private void LoadStudentsFromJson()
        {
            // Use IWebHostEnvironment to get the path to wwwroot
            string jsonPath = Path.Combine(_environment.WebRootPath, "students.json");
            Console.WriteLine($"Looking for JSON file at: {jsonPath}");

            if (File.Exists(jsonPath))
            {
                Console.WriteLine("JSON file found. Loading data...");
                string jsonData = File.ReadAllText(jsonPath);
                var jsonStudents = JsonSerializer.Deserialize<List<Student>>(jsonData);
                if (jsonStudents != null)
                {
                    // Combine students from JSON with in-memory students
                    students.AddRange(jsonStudents);
                    Console.WriteLine($"{jsonStudents.Count} students loaded from JSON.");
                }
                else
                {
                    Console.WriteLine("No students found in JSON.");
                }
            }
            else
            {
                Console.WriteLine("JSON file not found.");
            }
        }

        public List<Student> GetAllStudents()
        {
            return students;
        }

        public List<Student> SearchStudents(string searchTerm, int? minAge, int? maxAge, string sortBy, string sortOrder)
        {
            var filteredStudents = students.AsQueryable();

            if (!string.IsNullOrEmpty(searchTerm))
            {
                filteredStudents = filteredStudents.Where(s => s.Name.ToLower().Contains(searchTerm.ToLower()) || s.Major.ToLower().Contains(searchTerm.ToLower()));
            }

            if (minAge.HasValue)
            {
                filteredStudents = filteredStudents.Where(s => s.Age >= minAge.Value);
            }

            if (maxAge.HasValue)
            {
                filteredStudents = filteredStudents.Where(s => s.Age <= maxAge.Value);
            }

            if (!string.IsNullOrEmpty(sortBy))
            {
                if (sortBy == "name")
                {
                    filteredStudents = sortOrder == "desc" ? filteredStudents.OrderByDescending(s => s.Name) : filteredStudents.OrderBy(s => s.Name);
                }
                else if (sortBy == "age")
                {
                    filteredStudents = sortOrder == "desc" ? filteredStudents.OrderByDescending(s => s.Age) : filteredStudents.OrderBy(s => s.Age);
                }
            }

            return filteredStudents.ToList();
        }
    }
}
