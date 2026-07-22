using RestWithASPNet10.Configurations;
using RestWithASPNet10.Repositories;
using RestWithASPNet10.Repositories.Impl;
using RestWithASPNet10.Service;
using RestWithASPNet10.Service.Impl;

var builder = WebApplication.CreateBuilder(args);

builder.AddSerilogLogging();

builder.Services.AddControllers().AddContentNegotiation();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddOpenAPIConfig();
builder.Services.AddSwaggerConfig();

builder.Services.AddDatabaseConfiguration(builder.Configuration);
builder.Services.AddEvolveConfiguration(builder.Configuration, builder.Environment);
builder.Services.AddScoped<IPersonService, PersonServiceImplV1>();
builder.Services.AddScoped<IBooksService, BooksServiceImpl>();
builder.Services.AddScoped<PersonServiceImplV2>();

builder.Services.AddScoped(typeof(IRepository<>), typeof(GenericRepository<>));
builder.Services.Configure<RouteOptions>(options =>
{
    options.LowercaseUrls = true;
    options.LowercaseQueryStrings = true;
});

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.UseSwaggerSpecification();
app.UseScalarConfiguration();

app.Run();
