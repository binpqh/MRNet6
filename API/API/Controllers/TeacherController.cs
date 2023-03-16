using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services.Interfaces;
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
        [HttpPost]
        [Route("Create")]
        public async Task CreateTeacher(TeacherRequest teacher)
        {
            await _teacherrService.CreateteacherAsync(teacher);
        }

    }
}
