using Microsoft.OpenApi;

namespace RestWithASPNet10.Configurations
{
    public static class SwaggerConfig
    {
        private static readonly string AppName = "ASP.NET REST API with .Net 10";
        private static readonly string AppDescription = "REST API RESTFULL desenvolvida com ASP.NET 2 e .Net 10 para estudos e prática";

        public static IServiceCollection AddSwaggerConfig(this IServiceCollection services)
        {
            services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new OpenApiInfo
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
                options.CustomSchemaIds(type => type.FullName);
            });
            return services;
        }
        public static IApplicationBuilder UseSwaggerSpecification(this IApplicationBuilder app)
        {
            app.UseSwagger();
            app.UseSwaggerUI(options =>
            {
                options.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
                options.RoutePrefix = "swagger-ui";
                options.DocumentTitle = AppName;
            });
            return app;
        }
    }
}
