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
    public class EnrollController : ControllerBase
    {
        private readonly IEnrollService _enrollService;
        public EnrollController(IEnrollService enrollService) {
            _enrollService = enrollService;
        }
        [HttpGet]
        [Route("GetAll")]
        public async Task<List<EnrollRespone>> GetAllTeacherAsync()
        {
            return await _enrollService.GetAllAsync();
        }
        [HttpGet]
        [Route("Get")]
        public async Task<EnrollRespone> GetTeacherAsync(string id)
        {
            return await _enrollService.GetAsync(id);
        }
        [HttpPost]
        [Route("Create")]
        public async Task CreateTeacher(Enroll enroll)
        {
            await _enrollService.CreateAsync(enroll);
        }
        [HttpPut]
        [Route("Update")]
        public async Task UpdateTeacher(string id, Enroll enroll)
        {
            await _enrollService.UpdateAsync(id, enroll);
        }
        [HttpDelete]
        [Route("Delete")]
        public async Task DeleteTeacher(string id)
        {
            await _enrollService.DeleteAsync(id);
        }
    }
}
