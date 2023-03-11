using Services.Interfaces;
using Services.Models;
using Services.Services;

namespace API.Config
{
    public static class DatabaseConfig
    {
        public static void ConfigureDatabase(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddSingleton<IMongoDbContext>(provider =>
            {
                var connectionString = configuration.GetValue<string>("MongoConnection:ConnectionString");
                var databaseName = configuration.GetValue<string>("MongoConnection:DatabaseName");
                return new MongoDbContext(connectionString, databaseName);
            });

            //services.AddScoped<IStudentService, StudentService>();
            services.AddScoped<ITeacherService, TeacherService>();
            //services.AddScoped<ISubjectService, SubjectService>();
            services.AddScoped<IDepartmentService, DepartmentService>();
            //services.AddScoped<IEnrollService, EnrollService>();
        }
    }
}
