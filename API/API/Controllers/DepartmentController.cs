using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services.Interfaces;
using Services.Models;
using Services.Responses;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentController : ControllerBase
    {
        private readonly IDepartmentService _deptService;
        private readonly ITeacherService _teacherrService;
        public DepartmentController(IDepartmentService deptService, ITeacherService teacher)
        {
            _deptService = deptService;
            _teacherrService = teacher;
        }
        [HttpGet]
        public async Task<List<DepartmentResponse>> GetAllDepartmentAsync()
        {
            return await _deptService.GetAllAsync();
        }
        [HttpGet]
        [Route("Hihi")]
        public async Task<List<TeacherResponse>> GetAllTeacherAsync()
        {
            return await _teacherrService.GetAllAsync();
        }
        [HttpPost("id:string")]
        public async Task<DepartmentResponse> GetById(string id)
        {
            return await _deptService.GetByIdAsync(id);
        }

    }
}
