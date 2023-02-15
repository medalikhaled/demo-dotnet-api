using api.Models;

namespace api.Services;

public class StudentService
{ 
    private static List<Student> Students { get;  }
    private static int NextIndex = 3;


    static StudentService()
    {
        Students = new List<Student>
        {
            new Student { Id = 1, name = "dali", specialty = "CS" },
            new Student { Id = 2, name = "salma", specialty = "Science" },
            new Student { Id = 3, name = "leila", specialty = "Ae" },
        };
    }

    public static List<Student> GetAllStudents() => Students;

    public static Student? GetStudent(int id) => Students.FirstOrDefault((student) => student.Id == id );

    public static void AddStudent(Student student)
    {
        student.Id = NextIndex++;
        Students.Add(student);
    }

    public static void UpdateStudent(int id, Student student)
    {
        var index = Students.FindIndex((s) => s.Id == id);

        if (index == -1)
            return;

        Students[index] = student;
    }


    public static void DeleteStudent(int Id)
    {
        var student = GetStudent(Id);

        if (student is null)
            return;

        Students.Remove(student);
    } 



}