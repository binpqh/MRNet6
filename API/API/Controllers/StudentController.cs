using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services.Interfaces;
using Services.Models;
using Services.Requests;
using Services.Responses;
using Services.Services;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly IStudentService _studentService;
        public StudentController(IStudentService studentService) {
            _studentService = studentService;
        }
        [HttpGet]
        [Route("GetAll")]
        public async Task<List<StudentResponse>> GetAllAsync()
        {
            return await _studentService.GetAllStudentAsync();
        }
        [HttpGet]
        [Route("Get")]
        public async Task<Student> GetAsync(string id)
        {
            return await _studentService.GetStudentById(id);
        }
        [HttpPost]
        [Route("Create")]
        public async Task CreateAsync(Student student)
        {
            await _studentService.AddStudent(student);
        }
        [HttpPut]
        [Route("Update")]
        public async Task UpdateAsync(Student student)
        {
            await _studentService.UpdateStudent( student);
        }
        [HttpDelete]
        [Route("Delete")]
        public async Task DeleteAsync(string id)
        {
            await _studentService.DeleteStudent(id);
        }
    }
}
