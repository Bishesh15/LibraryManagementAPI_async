using LibraryManagementAPI.Models;
using LibraryManagementAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace LibraryManagementAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StudentController : ControllerBase
    {
        private readonly IStudentService _studentService;

        public StudentController(IStudentService studentService)
        {
            _studentService = studentService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
            => Ok(await _studentService.GetStudentsAsync());

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
            => Ok(await _studentService.GetStudentByIdAsync(id));

        [HttpPost]
        public async Task<IActionResult> Create(Student student)
        {
            await _studentService.AddStudentAsync(student);
            return Ok("Student saved successfully");
        }

        [HttpPut]
        public async Task<IActionResult> Update(Student student)
        {
            await _studentService.UpdateStudentAsync(student);
            return Ok("Student updated successfully");
        }
    }
}