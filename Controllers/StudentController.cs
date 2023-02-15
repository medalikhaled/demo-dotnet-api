using System.Data.Common;
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
    // GET
    [HttpGet]
    public ActionResult<List<Student>> getAll()
    {
        return StudentService.GetAllStudents();
    }

    [HttpGet("{id}")]
    public ActionResult<Student> getStudent(int id)
    {
        var student = StudentService.GetStudent(id);

        if (student is null)
            return NotFound();
        
        return student;
    }


    [HttpPost]
    public IActionResult addStudent(Student student)
    {
        StudentService.AddStudent(student);

        return CreatedAtAction("", new {id = student.Id}, student);
    }
    
    
    //TODO: Update & Delete
}