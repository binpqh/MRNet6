using Services.Models;
using Services.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Interfaces
{
    public interface IEnrollService
    {
        Task<List<EnrollRespone>> GetAllAsync();
        Task<EnrollRespone> GetAsync(string id);
        Task CreateAsync(Enroll enroll);
        Task UpdateAsync(string id,Enroll enroll);
        Task DeleteAsync(string id);
    }
}
