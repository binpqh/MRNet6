using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services.Interfaces;
using Services.Models;
using Services.Requests;
using Services.Responses;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class TeacherController : ControllerBase
    {
        private readonly ITeacherService _teacherrService;
        public TeacherController(ITeacherService teacher)
        {
            _teacherrService = teacher;
        }
        [HttpGet]
        [Route("GetAll")]
        public async Task<List<TeacherResponse>> GetAllTeacherAsync()
        {
            return await _teacherrService.GetAllAsync();
        }
        [HttpGet]
        [Route("Get")]
        public async Task<TeacherResponse> GetTeacherAsync(string id)
        {
            return await _teacherrService.GetAsync(id);
        }
        [HttpPost]
        [Route("Create")]
        public async Task CreateTeacher(TeacherRequest teacher)
        {
            await _teacherrService.CreateTeacherAsync(teacher);
        }
        [HttpPut]
        [Route("Update")]
        public async Task UpdateTeacher(string id,Teacher teacher)
        {
            await _teacherrService.UpdateTeacherAsync(id,teacher);
        }
        [HttpDelete]
        [Route("Delete")]
        public async Task DeleteTeacher(string id)
        {
            await _teacherrService.DeleteTeacherAsync(id);
        }
    }
}
