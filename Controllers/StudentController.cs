using System;
using System.Collections.Generic;
using Entity_Framework.Models;
using Entity_Framework.Services;
using Microsoft.AspNetCore.Mvc;

namespace Entity_Framework.Controllers
{
   [ApiController]
        [Route("[controller]")]
        public class StudentController : ControllerBase
        {
            private IStudentService _studentService;
            public StudentController(IStudentService studentService)
            {
                _studentService = studentService;
            }

            [HttpPost("/student")]
            public ActionResult<bool> Create(Student student)
            {
                try {

                    _studentService.Create(student);

                    return Ok($"Create new student successfully!");

                } catch (Exception e) {

                    return NotFound($"Error: {e.Message}");

                }
            }

            [HttpGet("/students")]
            public List<Student> GetAll() 
            {
                return _studentService.GetAll();
            }

            [HttpGet("/student/{id}")]
            public ActionResult<Student> GetOne(int id) 
            {
                return _studentService.GetOne(id);
            }

            [HttpPut("/student/{id}")]
            public IActionResult Edit(int id, Student student)
            {
                try 
                {
                    _studentService.Edit(id, student);

                    return Ok($"Edit a person successfully!");
                } 
                catch (Exception e)
                {
                    return NotFound($"Error: {e.Message}");
                }
            }

            [HttpDelete("/student/{id}")]
            public IActionResult Delete(int id)
            {
                try {

                    var person = _studentService.GetOne(id);

                    _studentService.Delete(id);

                    return Ok($"Delete person {person.FirstName} {person.LastName} successfully!");

                } catch (Exception e) {

                    return NotFound($"Error: {e.Message}");

                }
            }
        }
}