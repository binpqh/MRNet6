using MongoDB.Driver;
using Services.Interfaces;
using Services.Models;
using Services.Responses;
using MongoDB.Driver.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Services
{
    public class StudentService : IStudentService
    {
        private readonly IMongoCollection<Student> _studentCollection;

        public StudentService(IMongoDbContext context) {
            _studentCollection = context.GetCollection<Student>("Student");
        }
        public async Task AddStudent(Student student)
        {
            await _studentCollection.InsertOneAsync(student);
        }

        public async Task DeleteStudent(string id)
        {
            var filter = Builders<Student>.Filter.Eq(e => e.Id.ToString(),id);
            var delete = Builders<Student>.Update.Set(e=>e.IsDelete,true);
            await _studentCollection.UpdateOneAsync(filter,delete);
        }

        public async Task<List<StudentResponse>> GetAllStudentAsync()
        {
            
            var listStudent = await _studentCollection.AsQueryable().Where(t=> t.IsDelete != true).Select(t => new StudentResponse
            {
                Id = t.Id.ToString(),
                Name = t.Name,
                Age = t.Age,
                Gender= t.Gender,
                Email = t.Email,
                Phone = t.Phone,
                Address = t.Address,
                Major= t.Major
            }).ToListAsync();

            return listStudent;
        }

        public async Task<Student> GetStudentById(string id)
        {
            var student = await _studentCollection
                .Find(t => t.Id.ToString() == id).FirstOrDefaultAsync();
            if(student == null)
            {
                throw new Exception("Không tìm thấy học sinh này");
            };
            return student;
        }

        public async Task UpdateStudent(Student student)
        {
            var filter = Builders<Student>.Filter.Eq(e => e.Id,student.Id);
            var update = Builders<Student>.Update
                .Set(e => e.Name, student.Name)
                .Set(e => e.Address, student.Address)
                .Set(e => e.Major, student.Major)
                .Set(e => e.Email, student.Email)
                .Set(e => e.Age, student.Age)
                .Set(e => e.Gender, student.Gender)
                .Set(e => e.Phone, student.Phone)
                ;
            await _studentCollection.UpdateOneAsync(filter, update);
        }
    }
}
