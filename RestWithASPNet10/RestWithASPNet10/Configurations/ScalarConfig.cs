using Scalar.AspNetCore;

namespace RestWithASPNet10.Configurations
{
    public static class ScalarConfig
    {
        private static readonly string AppName = "ASP.NET REST API with .Net 10";
        public static WebApplication UseScalarConfiguration(this WebApplication app)
        {
            app.MapScalarApiReference("/scalar", options =>
            {
                options
                    .WithTitle(AppName)
                    .WithOpenApiRoutePattern("swagger/v1/swagger.json");

            });
            return app;
        }
    }
}
