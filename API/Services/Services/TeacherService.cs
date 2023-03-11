using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Driver.Linq;
using Services.Interfaces;
using Services.Models;
using Services.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Services
{
    public class TeacherService : ITeacherService
    {
        private readonly IMongoCollection<Teacher> _teacherCollection;
        private readonly IMongoCollection<Department> _departmentCollection;
        public TeacherService(IMongoDbContext context)
        {
            _teacherCollection = context.GetCollection<Teacher>("Teacher");
            _departmentCollection = context.GetCollection<Department>("Department");
        }

        public async Task<List<TeacherResponse>> GetAllAsync()
        {
            var listTeacher = await _teacherCollection.AsQueryable()
                .Select(t => new TeacherResponse
                {
                    Id = t.Id.ToString(),
                    Name = t.Name,
                    Birthday = t.BirthDay,
                    PhoneNumber = t.PhoneNumber,
                    Email = t.Email,
                    DepartmentName = t.Department.Name
                }).ToListAsync();
            return listTeacher;
        }
    }
}
