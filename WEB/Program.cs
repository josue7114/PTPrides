using Prueba.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews().AddRazorRuntimeCompilation();
builder.Services.AddRazorPages();

AppSettings.Empleados_Agregar = builder.Configuration.GetSection("AppSettings:Empleados_Agregar").Value;
AppSettings.Empleados_Modificar = builder.Configuration.GetSection("AppSettings:Empleados_Modificar").Value;
AppSettings.Empleados_Eliminar = builder.Configuration.GetSection("AppSettings:Empleados_Eliminar").Value;
AppSettings.Empleados_Listar = builder.Configuration.GetSection("AppSettings:Empleados_Listar").Value;
AppSettings.Permisos_Agregar = builder.Configuration.GetSection("AppSettings:Permisos_Agregar").Value;
AppSettings.Permisos_Modificar = builder.Configuration.GetSection("AppSettings:Permisos_Modificar").Value;
AppSettings.Permisos_Eliminar = builder.Configuration.GetSection("AppSettings:Permisos_Eliminar").Value;
AppSettings.Permisos_Listar = builder.Configuration.GetSection("AppSettings:Permisos_Listar").Value;
AppSettings.Tiendas_Agregar = builder.Configuration.GetSection("AppSettings:Tiendas_Agregar").Value;
AppSettings.Tiendas_Modificar = builder.Configuration.GetSection("AppSettings:Tiendas_Modificar").Value;
AppSettings.Tiendas_Eliminar = builder.Configuration.GetSection("AppSettings:Tiendas_Eliminar").Value;
AppSettings.Tiendas_Listar = builder.Configuration.GetSection("AppSettings:Tiendas_Listar").Value;
AppSettings.Usuarios_Agregar = builder.Configuration.GetSection("AppSettings:Usuarios_Agregar").Value;
AppSettings.Usuarios_Modificar = builder.Configuration.GetSection("AppSettings:Usuarios_Modificar").Value;
AppSettings.Usuarios_Eliminar = builder.Configuration.GetSection("AppSettings:Usuarios_Eliminar").Value;
AppSettings.Usuarios_Listar = builder.Configuration.GetSection("AppSettings:Usuarios_Listar").Value;
AppSettings.Perfiles_Listar = builder.Configuration.GetSection("AppSettings:Perfiles_Listar").Value;

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment()) {
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Inicio}/{action=Index}");

app.Run();