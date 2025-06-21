using ControlDeHabitos2.API.Data;
using ControlDeHabitos2.API.Interfaces;
using ControlDeHabitos2.API.Repositories;
using ControlDeHabitos2.API.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container
builder.Services.AddSingleton<IUsuarioService, UsuarioService>();
builder.Services.AddSingleton<IUsuarioRepository, UsuarioRepository>();


builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer(); // Necesario para Swagger
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "ControlDeHabitos2.API", Version = "v1" });
});





builder.Services.AddSingleton<IHabitoRepository, HabitoRepository>();
builder.Services.AddSingleton<IUsuarioRepository, UsuarioRepository>();


builder.Services.AddSingleton<IHabitoService, HabitoService>();
builder.Services.AddSingleton<IUsuarioService, UsuarioService>();

var app = builder.Build();

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));


// Configure the HTTP request pipeline
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();       // Middleware Swagger
    app.UseSwaggerUI();     // Interfaz Swagger
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.MapGet("/", context =>
{
    context.Response.Redirect("/swagger");
    return Task.CompletedTask;
});


app.Run();
