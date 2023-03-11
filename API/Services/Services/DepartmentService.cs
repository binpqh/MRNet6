using MongoDB.Bson;
using MongoDB.Driver;
using Services.Interfaces;
using Services.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Services.Services
{
    public class DepartmentService : IDepartmentService
    {
        private readonly IMongoCollection<Department> _departments;
        public DepartmentService(IMongoDbContext context)
        {
            _departments = context.GetCollection<Department>("Department");
        }
        public async Task<List<Department>> GetAllAsync()
        {
            var listDept = await _departments.Find(x=> true).ToListAsync();
            return listDept;
        }

        public async Task<Department> GetByIdAsync(string id)
        {
            var filter = Builders<Department>.Filter.Eq("_id", new ObjectId(id));
            var dept = await _departments.Find(filter).FirstOrDefaultAsync();
            if(dept == null)
            {
                throw new Exception("Không tìm thấy Department");
            }    
            return dept;
        }
    }
}
