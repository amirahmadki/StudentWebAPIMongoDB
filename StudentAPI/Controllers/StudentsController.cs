﻿
using StudentAPI.Services;
using StudentAPI.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace StudentAPI.Controllers
{
    
        [Route("api/[controller]")]
        [ApiController]
        public class StudentsController : ControllerBase
        {
            private readonly StudentService _studentService;

            public StudentsController(StudentService studentService)
            {
                _studentService = studentService;
            }

            [HttpGet]
            public ActionResult<List<Student>> Get() =>
                _studentService.Get();

            [HttpGet("{id:length(24)}", Name = "Getstudent")]
            public ActionResult<Student> Get(string id)
            {
                var student = _studentService.Get(id);

                if (student == null)
                {
                    return NotFound();
                }

                return student;
            }

            [HttpPost]
            public ActionResult<Student> Create(Student student)
            {
                _studentService.Create(student);

                return CreatedAtRoute("Getstudent", new { id = student.Id.ToString() }, student);
            }

            [HttpPut("{id:length(24)}")]
            public IActionResult Update(string id, Student studentIn)
            {
                var student = _studentService.Get(id);

                if (student == null)
                {
                    return NotFound();
                }

                _studentService.Update(id, studentIn);

                return NoContent();
            }

            [HttpDelete("{id:length(24)}")]
            public IActionResult Delete(string id)
            {
                var student = _studentService.Get(id);

                if (student == null)
                {
                    return NotFound();
                }

                _studentService.Remove(student.Id);

                return NoContent();
            }
        }
    }

