using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Driver.Linq;
using Services.Interfaces;
using Services.Models;
using Services.Requests;
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
       
        public TeacherService(IMongoDbContext context)
        {
            _teacherCollection = context.GetCollection<Teacher>("Teacher");
           
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

        public async Task CreateteacherAsync(TeacherRequest teacher)
        {

            var teacherInsert = new Teacher
            {
                Name = teacher.name,
                BirthDay = teacher.BirthDay,
                Email = teacher.email,
                Department = teacher.department,
                PhoneNumber = teacher.PhoneNumber
            };
            await _teacherCollection.InsertOneAsync(teacherInsert);
        }
    }
}
