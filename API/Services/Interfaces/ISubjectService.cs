using Services.Models;
using Services.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Interfaces
{
    public interface ISubjectService
    {
        Task<List<SubjectResponse>> GetAllAsync();
        Task<SubjectResponse> GetAsync(string id);
        Task DeleteAsync(string id);
        Task UpdateAsync(string id,Subject subject);
        Task CreateAsync(Subject subject);

    }
}
