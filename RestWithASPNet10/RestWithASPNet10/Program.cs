using RestWithASPNet10.Configurations;
using RestWithASPNet10.Repositories;
using RestWithASPNet10.Repositories.Impl;
using RestWithASPNet10.Service;
using RestWithASPNet10.Service.Impl;

var builder = WebApplication.CreateBuilder(args);

builder.AddSerilogLogging();

builder.Services.AddControllers().AddContentNegotiation();
builder.Services.AddDatabaseConfiguration(builder.Configuration);
builder.Services.AddEvolveConfiguration(builder.Configuration, builder.Environment);
builder.Services.AddScoped<IPersonService, PersonServiceImplV1>();
builder.Services.AddScoped<IBooksService, BooksServiceImpl>();
builder.Services.AddScoped<PersonServiceImplV2>();

builder.Services.AddScoped(typeof(IRepository<>), typeof(GenericRepository<>));

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
