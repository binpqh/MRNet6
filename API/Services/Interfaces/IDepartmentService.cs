using Services.Models;
using Services.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Interfaces
{
    public interface IDepartmentService
    {
        Task<List<DepartmentResponse>> GetAllAsync();
        Task<DepartmentResponse> GetByIdAsync(string id);

    }
}