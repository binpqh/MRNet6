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
    public class SubjectController : ControllerBase
    {
        private readonly ISubjectService _subjectService;
        public SubjectController(ISubjectService subjectService) {
            _subjectService = subjectService;
        }
        [HttpGet]
        [Route("GetAll")]
        public async Task<List<SubjectResponse>> GetAlSubjectAsync()
        {
            return await _subjectService.GetAllAsync();
        }
        [HttpGet]
        [Route("Get")]
        public async Task<SubjectResponse> GetTeacherAsync(string id)
        {
            return await _subjectService.GetAsync(id);
        }
        [HttpPost]
        [Route("Create")]
        public async Task CreateTeacher(Subject subject)
        {
            await _subjectService.CreateAsync(subject);
        }
        [HttpPut]
        [Route("Update")]
        public async Task UpdateTeacher(string id, Subject subject)
        {
            await _subjectService.UpdateAsync(id, subject);
        }
        [HttpDelete]
        [Route("Delete")]
        public async Task DeleteTeacher(string id)
        {
            await _subjectService.DeleteAsync(id);
        }
    }
}
