using MongoDB.Driver;

namespace Services.Models
{
    public class QLSVDbContext
    {
        private readonly IMongoDatabase _database;

        public QLSVDbContext(string connectionString, string databaseName)
        {
            var client = new MongoClient(connectionString);
            _database = client.GetDatabase(databaseName);
        }

        public IMongoCollection<Student> Students => _database.GetCollection<Student>("Student");
        public IMongoCollection<Teacher> Teachers => _database.GetCollection<Teacher>("Teacher");
        public IMongoCollection<Subject> Subjects => _database.GetCollection<Subject>("Subject");
        public IMongoCollection<Enroll> Enrolls => _database.GetCollection<Enroll>("Enroll");
        public IMongoCollection<Department> Departments => _database.GetCollection<Department>("Department");
    }
}
