using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services.Interfaces;
using Services.Models;
using Services.Responses;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class DepartmentController : ControllerBase
    {
        private readonly IDepartmentService _deptService;
        public DepartmentController(IDepartmentService deptService)
        {
            _deptService = deptService;
        }   
        [HttpGet]
        public async Task<List<DepartmentResponse>> GetAllDepartmentAsync()
        {
            return await _deptService.GetAllAsync();
        }
        [HttpPost("id:string")]
        public async Task<DepartmentResponse> GetById(string id)
        {
            return await _deptService.GetByIdAsync(id);
        }

    }
}
