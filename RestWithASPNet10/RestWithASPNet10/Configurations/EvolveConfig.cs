using EvolveDb;
using Microsoft.Data.SqlClient;
using Serilog;

namespace RestWithASPNet10.Configurations
{
    public static class EvolveConfig
    {
        public static IServiceCollection AddEvolveConfiguration(this IServiceCollection services, IConfiguration configuration, IWebHostEnvironment environment)
        {
            if(environment.IsDevelopment())
            {
                var connectionString = configuration["MSSQLConnection:MSSQLConnectionString"];
                if (connectionString == null)
                {
                    throw new ArgumentNullException("Connection string MSSQLConnectionString is null");
                }
                try
                {
                    using var evolveConnection = new SqlConnection(connectionString);
                    var evolve = new Evolve(evolveConnection, msg => Log.Information(msg))
                    {
                        Locations = new List<string> { "db/migrations", "db/dataset" },
                        IsEraseDisabled = true,
                    };
                    evolve.Migrate();
                }
                catch(Exception ex)
                {
                    Log.Error("Database migration failed", ex);
                    throw;
                }
            }
            return services;
        }
    }
}
