using Microsoft.AspNetCore.Mvc.Razor;
using MongoDB.Bson;
using MongoDB.Driver;
using Services.Helper;
using Services.Interfaces;
using Services.Models;
using Services.Responses;
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
        public async Task<List<DepartmentResponse>> GetAllAsync()
        {
            var listDept = await _departments
                .Find(x => true)
                .Project(x => new DepartmentResponse
                {
                    id = x.Id.ToString(),
                    name = x.Name
                }).ToListAsync();
            return listDept;
        }

        public async Task<DepartmentResponse> GetByIdAsync(string id)
        {
            if(!HelperValidHex.Check(id))
            {
                throw new Exception("Id không hợp lệ kìa má");
            }    
            var filter = Builders<Department>.Filter.Eq("_id", new ObjectId(id));
            var dept = await _departments.Find(filter)
                .Project(d=> new DepartmentResponse
                {
                    id = d.Id.ToString(),
                    name = d.Name
                })
                .FirstOrDefaultAsync();
            if(dept == null)
            {
                throw new Exception("Không tìm thấy Department");
            }    
            return dept;
        }
    }
}
