using Albums.Modelos;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Albums.Data;

var builder = WebApplication.CreateBuilder(args);

// Configuraci�n inicial del constructor de la aplicaci�n

// Agregar servicios al contenedor de servicios
builder.Services.AddRazorPages(); // Agrega servicios para las p�ginas Razor

// Configurar el contexto de base de datos para la aplicaci�n
builder.Services.AddDbContext<AlbumsContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("AlbumConnection")
                        ?? throw new InvalidOperationException("Connection string 'AlbumsContext' not found.")));

// Inyecci�n de dependencias para el contexto de base de datos
builder.Services.AddDbContext<DBAContext>();



// Construcci�n de la aplicaci�n
var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var context = scope.ServiceProvider.GetRequiredService<AlbumsContext>();
    context.Database.Migrate();
}

// Configuraci�n del pipeline de solicitudes HTTP

// Middleware para manejar excepciones en caso de errores
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error"); // Redirige a la p�gina de error en producci�n
    app.UseHsts(); // Aplica HTTP Strict Transport Security (HSTS)
}

app.UseHttpsRedirection(); // Redirecci�n HTTP a HTTPS
app.UseStaticFiles(); // Habilita el uso de archivos est�ticos (CSS, JS, im�genes, etc.)

app.UseRouting(); // Configura el enrutamiento de solicitudes

app.UseAuthorization(); // Configura la autorizaci�n basada en pol�ticas

app.MapRazorPages(); // Mapea las p�ginas Razor en la aplicaci�n

app.Run(); // Ejecuta la aplicaci�n

