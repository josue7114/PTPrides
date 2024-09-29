using Microsoft.EntityFrameworkCore;
using Prueba.Interface;
using Prueba.Logic;
using Prueba.Models;
using Prueba.Models.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<P1700Context>(
    options =>
    {
        options.UseSqlServer(builder.Configuration.GetConnectionString("SqlConnection"));
    });

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IEmpleados, LEmpleados>();
builder.Services.AddScoped<IPerfil, LPerfil>();
builder.Services.AddScoped<IPermisos, LPermisos>();
builder.Services.AddScoped<ITiendas, LTiendas>();
builder.Services.AddScoped<IUsuarios, LUsuarios>();
StringConexion.ConexionSQL = builder.Configuration.GetConnectionString("SqlConnection");

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment()) {
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();