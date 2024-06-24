using Albums.Modelos;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Albums.Data;

var builder = WebApplication.CreateBuilder(args);

// Configuración inicial del constructor de la aplicación

// Agregar servicios al contenedor de servicios
builder.Services.AddRazorPages(); // Agrega servicios para las páginas Razor

// Configurar el contexto de base de datos para la aplicación
builder.Services.AddDbContext<AlbumsContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("AlbumConnection")
                        ?? throw new InvalidOperationException("Connection string 'AlbumsContext' not found.")));

// Inyección de dependencias para el contexto de base de datos
builder.Services.AddDbContext<DBAContext>();



// Construcción de la aplicación
var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var context = scope.ServiceProvider.GetRequiredService<AlbumsContext>();
    context.Database.Migrate();
}

// Configuración del pipeline de solicitudes HTTP

// Middleware para manejar excepciones en caso de errores
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error"); // Redirige a la página de error en producción
    app.UseHsts(); // Aplica HTTP Strict Transport Security (HSTS)
}

app.UseHttpsRedirection(); // Redirección HTTP a HTTPS
app.UseStaticFiles(); // Habilita el uso de archivos estáticos (CSS, JS, imágenes, etc.)

app.UseRouting(); // Configura el enrutamiento de solicitudes

app.UseAuthorization(); // Configura la autorización basada en políticas

app.MapRazorPages(); // Mapea las páginas Razor en la aplicación

app.Run(); // Ejecuta la aplicación

