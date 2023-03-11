using API.Helper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services.Interfaces;
using Services.Models;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentController : ControllerBase
    {
        private readonly IDepartmentService _deptService;
        public DepartmentController(IDepartmentService deptService)
        {
            _deptService = deptService;
        }
        [HttpGet]
        public async Task<List<Department>> GetAllDepartmentAsync()
        {
            return await _deptService.GetAllAsync();
        }
        [HttpPost("id:string")]
        public async Task<Department> GetById(string id)
        {
            if(HelperValidHex.Check(id))
            {
                return await _deptService.GetByIdAsync(id);
            }    
            else
            {
                throw new Exception("Id không hợp lệ");
            }    
        }

    }
}
