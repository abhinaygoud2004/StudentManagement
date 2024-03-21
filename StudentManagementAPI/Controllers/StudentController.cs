using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using StudentManagementService;
using Common.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace StudentManagementAPI.Controllers
{

    [Route("api/[controller]")]
    public class StudentController : Controller
    {
        private readonly IStudentService _studentService;
        public StudentController(IStudentService studentService)
        {
            _studentService = studentService;
        }

        [HttpGet]
        [Route("GetStudentById")]
        public async Task<ActionResult<Student>>GetStudentById(int id)
        {
            return await _studentService.GiveMeStudentById(id);
        }

        [HttpGet]
        [Route("GetAllStudents")]
        public async Task<ActionResult<List<Student>>> GetAllStudents()
        {
            return await _studentService.GiveAllStudents();
        }

        [HttpPost]
        [Route("AddStudent")]
        public async Task<ActionResult<bool>> AddStudent(Student newStudent)
        {
            return await _studentService.AddStudent(newStudent);
            //return Ok(); // or return appropriate response
        }

        [HttpDelete]
        [Route("DeleteStudent")]
        public async Task<ActionResult<bool>> DeleteStudent(int id)
        {
            return await _studentService.DeleteStudent(id);
        }

        [HttpPut]
        [Route("UpdateStudent")]
        public async Task<ActionResult<bool>> UpdateStudent(Student student)
        {
            return await _studentService.UpdateStudent(student);
        }

        [HttpGet]
        [Route("GetAllStudentsStartingWithA")]
        public async Task<ActionResult<List<Student>>> GetAllStudentsStartingWithA()
        {
            //StudentService studentService = new StudentService();
            return await _studentService.GiveStudentsStartingWithA();
        }

        [HttpGet]
        [Route("GetAllStudentsWithA")]
        public async Task<ActionResult<List<Student>>> GetAllStudentsWithA()
        {
            //StudentService studentService = new StudentService();
            return await _studentService.GiveStudentsWithAInTheirName();
        }
    }
}