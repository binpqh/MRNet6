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
    public class SubjectService : ISubjectService
    {
        private readonly IMongoCollection<Subject> _subjectCollection;
        private readonly IMongoCollection<Teacher> _teacherCollection;
        public SubjectService(IMongoDbContext context) {
            _subjectCollection = context.GetCollection<Subject>("Subject");
            _teacherCollection = context.GetCollection<Teacher>("Teacher");
        }
        public async Task CreateAsync(Subject subject)
        {
            if (subject == null)
            {
                throw new Exception("Không thể thêm môn học!");
            }
            await _subjectCollection.InsertOneAsync(subject);
        }

        public async Task DeleteAsync(string id)
        {
            var filter = Builders<Subject>.Filter.Eq(e => e.Id.ToString(), id);
            var delete = Builders<Subject>.Update.Set(e => e.IsDelete, true);
            await _subjectCollection.UpdateOneAsync(filter, delete);
        }

        public async Task<List<SubjectResponse>> GetAllAsync()
        {
            //var listSubject = _subjectCollection.AsQueryable()
            //    .Where(e=>e.IsDelete !=true)
            //    .Join(
            //        _teacherCollection.AsQueryable(),
            //        subject=> subject.TeacherId,
            //        teacher=> teacher.Id,
            //        (subject,teacher)=> new Subjecta
            var listSubject = await _subjectCollection
            .Find(e => e.IsDelete != true)
            .ToListAsync();

            if (listSubject.Count <= 0)
            {
                throw new Exception("Danh sách môn học rỗng!");
            }

            var subjectResponses = listSubject.Select(e => new SubjectResponse
            {
                Id = e.Id.ToString(),
                Name = e.Name,
                Code = e.Code,
                Teacher = _teacherCollection.Find(t => t.Id == e.TeacherId).FirstOrDefault(),
            });
            return subjectResponses.ToList();
        }

        public async Task<SubjectResponse> GetAsync(string id)
        {
            var listSubject = await _subjectCollection
           .Find(e => e.IsDelete != true && e.Id.ToString()==id)
           .ToListAsync();

            if (listSubject.Count <= 0)
            {
                throw new Exception("Danh sách môn học rỗng!");
            }

            var subjectResponses = listSubject.Select(e => new SubjectResponse
            {
                Id = e.Id.ToString(),
                Name = e.Name,
                Code = e.Code,
                Teacher = _teacherCollection.Find(t => t.Id == e.TeacherId).FirstOrDefault(),
            }).FirstOrDefault();
            if(subjectResponses == null)
            {
                throw new Exception("Không tìm thấy môn học này");
            }    
            return subjectResponses;
        }

        public async Task UpdateAsync(string id, Subject subject)
        {
            var filter = Builders<Subject>.Filter.Eq(e => e.Id.ToString(), id);
            var update = Builders<Subject>.Update.Set(e => e, subject);
            await _subjectCollection.UpdateOneAsync(filter, update);
        }
    }
}
