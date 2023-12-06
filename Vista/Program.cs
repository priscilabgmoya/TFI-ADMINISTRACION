using Negocio.Contratos;
using Negocio.Servicios;
using System.Security.Claims;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
//Inycciones de dependencia
builder.Services.AddScoped<ISesionService, SesionService>();
builder.Services.AddScoped<IEmpleadoService, EmpleadoService>();
builder.Services.AddScoped<IAsignarTareasService, AsignarTareasService>();
builder.Services.AddScoped<IGestionarProyectoService, GestionarProyectoService>();

builder.Services.AddAuthentication("MiCookieDeAutenticacion").AddCookie("MiCookieDeAutenticacion", options =>
{
    options.Cookie.Name = "MiCookieDeAutenticacion";
    options.LoginPath = "/Login/IniciarSesion";
    options.AccessDeniedPath = "/Login/AccesoDenegado";
});

builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("DebeSerAdmininstrativo",
        policy => policy.RequireClaim("Empleado", "Administrativo"));
    options.AddPolicy("DebeSerLiderDeProyecto",
        policy => policy.RequireClaim("Empleado", "LiderDeProyecto"));
    options.AddPolicy("DebeEstarAutenticado",
        policy => policy.RequireClaim("Empleado", "Normal"));
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}


app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();    

app.UseAuthorization();

app.MapRazorPages();

app.Run();
