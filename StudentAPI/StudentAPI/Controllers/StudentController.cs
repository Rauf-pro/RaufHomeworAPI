using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StudentAPI.DATA;
using StudentAPI.Models;
using StudentAPI.Models.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly AppDbContext _context;

        public StudentController(AppDbContext context)
        {
            _context = context;
        }
        [HttpGet]
        public IActionResult GetStudent()
        {
            List<DtoStudent> dtoStudents = new List<DtoStudent>();
            foreach (var item in _context.Students.ToList())
            {
                DtoStudent dtoStudent = new DtoStudent();

                dtoStudent.Id = item.Id;
                dtoStudent.Name = item.Name;
                dtoStudent.Surname = item.Surname;
                dtoStudent.Age = item.Age;
                dtoStudent.Email = item.Email;
               
               

                dtoStudents.Add(dtoStudent);
            };

            return Ok(dtoStudents);
        }
        [HttpGet("{id}")]
        public IActionResult GetStudent(int? id)
        {
            if (id == null)
            {
                

                return StatusCode(StatusCodes.Status400BadRequest, "Wrong");
            }

            Student student = _context.Students.Find(id);
            if (student == null)
            {
                ModelState.AddModelError("", "Error, Wrong Command");
                return StatusCode(StatusCodes.Status404NotFound, ModelState);

               
            }

            return Ok(student);
        }
        [HttpPost]
        public IActionResult CreateStudent(Student model)
        {
            if (ModelState.IsValid)
            {
                
                _context.Students.Add(model);
                _context.SaveChanges();
                return Ok();
            }

            return BadRequest();
        }
    }
}
