using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;
using System.Xml.Serialization;
using System.IO;

public class Student
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int Age { get; set; }
    public string Major { get; set; }
}

public class Program
{
    public static void Main(string[] args)
    {
        List<Student> students = new List<Student>
        {
            new Student { Id = 1, Name = "Alice", Age = 20, Major = "Computer Science" },
            new Student { Id = 2, Name = "Bob", Age = 22, Major = "Mathematics" },
            new Student { Id = 3, Name = "Charlie", Age = 21, Major = "Physics" },
            new Student { Id = 4, Name = "David", Age = 19, Major = "Engineering" }
        };

        // Rechercher des étudiants majeurs
        var adultStudents = students.Where(s => s.Age >= 18);
        Console.WriteLine("Adult Students:");
        foreach (var student in adultStudents)
        {
            Console.WriteLine(student.Name);
        }

        // Rechercher par filière
        var csStudents = students.Where(s => s.Major == "Computer Science");
        Console.WriteLine("Computer Science Students:");
        foreach (var student in csStudents)
        {
            Console.WriteLine(student.Name);
        }

        // Trier les étudiants par âge
        var sortedStudents = students.OrderBy(s => s.Age);
        Console.WriteLine("Students sorted by age:");
        foreach (var student in sortedStudents)
        {
            Console.WriteLine($"{student.Name}, Age: {student.Age}");
        }

        // Requête globale sur tous les champs
        var searchTerm = "Alice";
        var searchResults = students.Where(s => s.Name.Contains(searchTerm) || s.Major.Contains(searchTerm));
        Console.WriteLine("Search results:");
        foreach (var student in searchResults)
        {
            Console.WriteLine(student.Name);
        }

        // Sérialisation en JSON
        string json = JsonConvert.SerializeObject(students, Formatting.Indented);
        Console.WriteLine("JSON format:");
        Console.WriteLine(json);

        // Sérialisation en XML
        XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<Student>));
        using (StringWriter textWriter = new StringWriter())
        {
            xmlSerializer.Serialize(textWriter, students);
            string xml = textWriter.ToString();
            Console.WriteLine("XML format:");
            Console.WriteLine(xml);
        }
    }
}
