using RestWithASPNet10.Configurations;
using RestWithASPNet10.Service;
using RestWithASPNet10.Service.Impl;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddDatabaseConfiguration(builder.Configuration);

builder.Services.AddScoped<IPersonService, PersonServiceImpl>();

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
