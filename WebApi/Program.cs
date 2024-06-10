using Domain.Data;
using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Repositories;
using Repository;
using Service;
using Service.Dtos;

var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<ColegioDataContext>(options =>
{
    options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
});

// Add services to the container.
builder.Services.AddScoped(typeof(IRepository<>), typeof(BaseRepository<>));
builder.Services.AddScoped<IRepository<AlumnoGrado>, AlumnoGradoRepository>();
builder.Services.AddScoped<IService<AlumnoDto>, AlumnoService>();
builder.Services.AddScoped<IService<ProfesorDto>, ProfesorService>();
builder.Services.AddScoped<IService<GradoDto>, GradoService>();
builder.Services.AddScoped<IService<AlumnoGradoDto>, AlumnoGradoService>();


builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAngularApp", policy =>
    {
        policy.WithOrigins("http://localhost:4200")
            .AllowAnyMethod()
            .AllowAnyHeader();
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseCors("AllowAngularApp");

    using (var scope = app.Services.CreateScope())
    {
        using (var context = scope.ServiceProvider.GetRequiredService<ColegioDataContext>())
        {
            context.Database.EnsureCreated();
        }
    }

    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();