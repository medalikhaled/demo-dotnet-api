using System.Data.Common;
using api.Data;
using api.Models;
using api.Services;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers;

[EnableCors("examplePolicy")]
[ApiController]
[Route("[controller]")]
public class StudentController : ControllerBase
{
    private readonly ApplicationDbContext _db;
    public StudentController(ApplicationDbContext db)
    {
        _db = db;
    }


    // GET
    [HttpGet]
    public async Task<ActionResult<List<Student>>> GetAll()
    {
        //return StudentService.GetAllStudents();
        return _db.Students.ToList();

    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Student>> GetStudent(int id)
    {
        //var student = StudentService.GetStudent(id);
        var student = _db.Students.SingleOrDefault(x => x.Id == id);

        if (student is null)
            return NotFound();

        return student;
    }


    [HttpPut("{id}")]
    public async Task<ActionResult> UpdateStudent(int id, Student student)
    {
        var updatedStudent = await _db.Students.FindAsync(id);

        if (updatedStudent is null)
            return NotFound();

        updatedStudent.Name = student.Name;
        updatedStudent.Specialty = student.Specialty;

        await _db.SaveChangesAsync();

        return Ok(updatedStudent);

    }

    [HttpPost]
    public async Task<ActionResult> CreateStudent(Student student)
    {
        //StudentService.AddStudent(student);
        _db.Students.Add(student);
        await _db.SaveChangesAsync();

        return Ok(student);
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> RemoveStudent(int id)
    {
        var student = await _db.Students.FindAsync(id);

        if (student is null)
            return NotFound();

        _db.Students.Remove(student);
        await _db.SaveChangesAsync();

        return NoContent(); 
    }
    
  
}