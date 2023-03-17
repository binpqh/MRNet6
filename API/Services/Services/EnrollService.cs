using MongoDB.Driver;
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
    public class EnrollService : IEnrollService
    {
        private readonly IMongoCollection<Enroll> _enrollCollection;
        private readonly IMongoCollection<Student> _studentCollection;
        private readonly IMongoCollection<Subject> _subjectCollection;
        public EnrollService(IMongoDbContext context) {
            _enrollCollection = context.GetCollection<Enroll>("Enroll");
            _studentCollection = context.GetCollection<Student>("Student");
            _subjectCollection = context.GetCollection<Subject>("Subject");
        }
        public async Task CreateAsync(Enroll enroll)
        {
            var res = new Enroll
            {
                DateEnroll = DateTime.Now,
                StudentId = enroll.StudentId,
                SubjectId = enroll.SubjectId,
            };
            await _enrollCollection.InsertOneAsync(res);
        }

        public async Task DeleteAsync(string id)
        {
            var filter = Builders<Enroll>.Filter.Eq(e => e.Id.ToString(), id);
            var delete = Builders<Enroll>.Update.Set(e => e.IsDelete, true);
            await _enrollCollection.UpdateOneAsync(filter, delete);
        }

        public async Task<List<EnrollRespone>> GetAllAsync()
        {
            var listEnroll = await _enrollCollection.Find(e => e.IsDelete != true).ToListAsync();
            if(listEnroll == null)
            {
                throw new Exception("Danh sách dăng kí rỗng");
            }
            var listRes = listEnroll.Select(e=> new EnrollRespone
            {
                Id = e.Id.ToString(),
                StudentName = _studentCollection.Find(s=>s.Id==e.StudentId).FirstOrDefault().Name,
                SubjectName = _subjectCollection.Find(s => s.Id == e.SubjectId).FirstOrDefault().Name,
                SubjectCode = _subjectCollection.Find(s => s.Id == e.SubjectId).FirstOrDefault().Code,
            }).ToList();
            return listRes;
        }

        public async Task<EnrollRespone> GetAsync(string id)
        {
            var listEnroll = await _enrollCollection.Find(e => e.IsDelete != true).ToListAsync();
            if (listEnroll == null)
            {
                throw new Exception("Danh sách đăng kí rỗng");
            }
            var res = listEnroll.Select(e => new EnrollRespone
            {
                Id = e.Id.ToString(),
                StudentName = _studentCollection.Find(s => s.Id == e.StudentId).FirstOrDefault().Name,
                SubjectName = _subjectCollection.Find(s => s.Id == e.SubjectId).FirstOrDefault().Name,
                SubjectCode = _subjectCollection.Find(s => s.Id == e.SubjectId).FirstOrDefault().Code,
            }).FirstOrDefault();
            if(res == null)
            {
                throw new Exception("Không tìm thấy enroll");
            }
            return res;
        }

        public async Task UpdateAsync(string id, Enroll enroll)
        {
            var filter = Builders<Enroll>.Filter.Eq(e=>e.Id.ToString(), id);
            var update = Builders<Enroll>.Update.Set(e => e, enroll);
            await _enrollCollection.UpdateOneAsync(filter, update);
        }
    }
}
