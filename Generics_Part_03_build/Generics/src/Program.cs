using Generics;

var students = new Store<Student>();
students.Add(new Student { Id = 1, Name = "Ahmed" });
students.Add(new Student { Id = 2, Name = "Mona" });
students.Add(new Student { Id = 3, Name = "Omar" });
students.Add(new Student { Id = 4, Name = "Sara" });
students.Add(new Student { Id = 5, Name = "Youssef" });

var courses = new Store<Course>();
courses.Add(new Course { Id = 101, Title = "C#", Price = 1500m });
courses.Add(new Course { Id = 102, Title = "ASP.NET Core", Price = 2000m });
courses.Add(new Course { Id = 103, Title = "SQL Server", Price = 1200m });

Console.WriteLine("=== Get By Id ===");

var student = students.GetById(3);
Console.WriteLine($"Student: {student?.Id} - {student?.Name}");

var course = courses.GetById(102);
Console.WriteLine($"Course: {course?.Id} - {course?.Title} - {course?.Price}");

Console.WriteLine();
Console.WriteLine("=== Duplicate Id ===");

try
{
    students.Add(new Student { Id = 3, Name = "Duplicate Student" });
}
catch (InvalidOperationException ex)
{
    Console.WriteLine(ex.Message);
}

Console.WriteLine();
Console.WriteLine("=== Page 2, Size 2 ===");

foreach (var item in students.GetAll().Page(2, 2))
{
    Console.WriteLine($"{item.Id} - {item.Name}");
}

Console.WriteLine();
Console.WriteLine("=== FindById on List<Course> ===");

var courseList = new List<Course>
{
    new Course { Id = 201, Title = "HTML", Price = 500m },
    new Course { Id = 202, Title = "CSS", Price = 600m },
    new Course { Id = 203, Title = "JavaScript", Price = 900m }
};

var foundCourse = courseList.FindById(202);
Console.WriteLine($"{foundCourse?.Id} - {foundCourse?.Title} - {foundCourse?.Price}");

// var strings = new Store<string>(); // must NOT compile
