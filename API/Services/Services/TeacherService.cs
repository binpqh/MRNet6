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
                .Where(t=>t.IsDelete != true)
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

        public async Task CreateTeacherAsync(TeacherRequest teacher)
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

        public async Task UpdateTeacherAsync(string id, Teacher teacher)
        {
            var filter = Builders<Teacher>.Filter.Eq(t => t.Id.ToString(), id);
            var update = Builders<Teacher>.Update.Set(t => t, teacher);
            await _teacherCollection.UpdateOneAsync(filter, update);
        }

        public async Task DeleteTeacherAsync(string id)
        {
            var filter = Builders<Teacher>.Filter.Eq(t => t.Id.ToString(), id);
            var update = Builders<Teacher>.Update.Set(t=>t.IsDelete, true);
            await _teacherCollection.UpdateOneAsync(filter, update);
        }

        public async Task<TeacherResponse> GetAsync(string id)
        {
            var res = await _teacherCollection.AsQueryable()
                .Where(e => e.Id.ToString() == id)
                .Select(e => new TeacherResponse
                {
                    Id = e.Id.ToString(),
                    Name = e.Name,
                    Birthday = e.BirthDay,
                    PhoneNumber = e.PhoneNumber,
                    Email = e.Email,
                    DepartmentName = e.Department.Name
                }).FirstOrDefaultAsync();
            return res;
        }
    }
}
