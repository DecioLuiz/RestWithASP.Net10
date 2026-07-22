using Microsoft.OpenApi;

namespace RestWithASPNet10.Configurations
{
    public static class OpenAPIConfig
    {
        private static readonly string AppName = "ASP.NET REST API with .Net 10";
        private static readonly string AppDescription = "REST API RESTFULL desenvolvida com ASP.NET 2 e .Net 10 para estudos e prática";

        public static IServiceCollection AddOpenAPIConfig(this IServiceCollection services)
        {
            services.AddSingleton(new OpenApiInfo
            {
                Title = AppName,
                Version = "v1",
                Description = AppDescription,
                Contact = new OpenApiContact
                {
                    Name = "Décio Luíz",
                    Email = "decioluiz@msn.com"
                }
            });
            return services;
        }
    }
}
