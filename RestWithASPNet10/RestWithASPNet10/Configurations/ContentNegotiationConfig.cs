using Microsoft.Net.Http.Headers;

namespace RestWithASPNet10.Configurations
{
    public static class ContentNegotiationConfig
    {
        public static IMvcBuilder AddContentNegotiation(this IMvcBuilder builder)
        {
            return builder.AddMvcOptions(options =>
            {
                options.RespectBrowserAcceptHeader = true; // Respect the Accept header
                options.ReturnHttpNotAcceptable = true; // Return 406 Not Acceptable if the requested format is not supported

                options.FormatterMappings.SetMediaTypeMappingForFormat("xml", MediaTypeHeaderValue.Parse("application/xml"));
                options.FormatterMappings.SetMediaTypeMappingForFormat("json", MediaTypeHeaderValue.Parse("application/json"));
            }).AddXmlSerializerFormatters();
        }
    }
}
