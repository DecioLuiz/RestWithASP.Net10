using RestWithASPNet10.Configurations;
using RestWithASPNet10.Repositories;
using RestWithASPNet10.Repositories.Impl;
using RestWithASPNet10.Service;
using RestWithASPNet10.Service.Impl;

var builder = WebApplication.CreateBuilder(args);

builder.AddSerilogLogging();

builder.Services.AddControllers();
builder.Services.AddDatabaseConfiguration(builder.Configuration);
builder.Services.AddEvolveConfiguration(builder.Configuration, builder.Environment);
builder.Services.AddScoped<IPersonService, PersonServiceImpl>();
builder.Services.AddScoped<IPersonRepository, PersonRepository>();
builder.Services.AddScoped<IBooksService, BooksServiceImpl>();
builder.Services.AddScoped<IBooksRepository, BooksRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
