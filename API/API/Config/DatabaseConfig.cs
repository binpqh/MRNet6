using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Services.Interfaces;
using Services.Models;
using Services.Services;
using System.Text;

namespace API.Config
{
    public static class DatabaseConfig
    {
        public static void ConfigureDatabase(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddTransient<IMongoDbContext>(provider =>
            {
                var connectionString = configuration.GetValue<string>("MongoConnection:ConnectionString");
                var databaseName = configuration.GetValue<string>("MongoConnection:DatabaseName");
                return new MongoDbContext(connectionString, databaseName);
            });
            services.AddSingleton(new SymmetricSecurityKey(Encoding.ASCII.GetBytes(configuration.GetSection("JWT:Secret").Value)));
            services.AddTransient<IAuthService, AuthService>();
            services.AddTransient<ITokenService, TokenService>();
            services.AddScoped<IStudentService, StudentService>();
            services.AddScoped<ITeacherService, TeacherService>();
            services.AddScoped<ISubjectService, SubjectService>();
            services.AddScoped<IDepartmentService, DepartmentService>();
            services.AddScoped<IEnrollService, EnrollService>();
            
        }
    }
}
