using Microsoft.EntityFrameworkCore;
using RestWithASPNet10.Model.Context;

namespace RestWithASPNet10.Configurations
{
    public static class DatabaseConfig
    {
        public static IServiceCollection AddDatabaseConfiguration(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration["MSSQLConnection:MSSQLConnectionString"];
            if (connectionString == null)
            {
                throw new ArgumentNullException("Connection string MSSQLConnectionString is null");
            }
            services.AddDbContext<MSSQLContext>(options =>
                options.UseSqlServer(connectionString));
            return services;
        }
    }
}

