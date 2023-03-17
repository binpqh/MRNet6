using Services.Models;
using Services.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Interfaces
{
    public interface IStudentService
    {
        Task<List<StudentResponse>> GetAllStudentAsync();
        Task<Student> GetStudentById(string id);
        Task AddStudent(Student student);
        Task UpdateStudent(string id,Student student);
        Task DeleteStudent(string id);
    }
}
