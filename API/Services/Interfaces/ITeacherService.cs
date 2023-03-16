using Services.Requests;
using Services.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Interfaces
{
    public interface ITeacherService
    {
        Task<List<TeacherResponse>> GetAllAsync();
        Task CreateteacherAsync(TeacherRequest teacher);
    }
}
