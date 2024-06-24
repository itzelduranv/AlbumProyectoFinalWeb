using Albumsss.Modelos;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Agrega servicios al contenedor de dependencias.
builder.Services.AddRazorPages(); // Servicio para habilitar Razor Pages
builder.Services.AddDbContext<AlbumContext>(options =>
    // Configura el contexto de la base de datos para usar SQL Server con la cadena de conexión especificada
    options.UseSqlServer(builder.Configuration.GetConnectionString("AlbumConnection"))
);

var app = builder.Build(); // Construye la aplicación web

// Configura el pipeline de solicitudes HTTP.
if (!app.Environment.IsDevelopment())
{
    // En producción, usa un controlador de excepciones genérico y habilita HSTS
    app.UseExceptionHandler("/Error");
    // El valor predeterminado de HSTS es 30 días. Puede cambiarse para escenarios de producción, ver https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection(); // Redirige todas las solicitudes HTTP a HTTPS
app.UseStaticFiles(); // Habilita el servicio de archivos estáticos

app.UseRouting(); // Habilita el enrutamiento de solicitudes

app.UseAuthorization(); // Habilita la autorización (aunque no se está configurando en este ejemplo)

app.MapRazorPages(); // Mapea las Razor Pages a las rutas de la aplicación

app.Run(); // Ejecuta la aplicación

