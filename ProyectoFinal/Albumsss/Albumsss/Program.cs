using Albumsss.Modelos;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Agrega servicios al contenedor de dependencias.
builder.Services.AddRazorPages(); // Servicio para habilitar Razor Pages
builder.Services.AddDbContext<AlbumContext>(options =>
    // Configura el contexto de la base de datos para usar SQL Server con la cadena de conexi�n especificada
    options.UseSqlServer(builder.Configuration.GetConnectionString("AlbumConnection"))
);

var app = builder.Build(); // Construye la aplicaci�n web

// Configura el pipeline de solicitudes HTTP.
if (!app.Environment.IsDevelopment())
{
    // En producci�n, usa un controlador de excepciones gen�rico y habilita HSTS
    app.UseExceptionHandler("/Error");
    // El valor predeterminado de HSTS es 30 d�as. Puede cambiarse para escenarios de producci�n, ver https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection(); // Redirige todas las solicitudes HTTP a HTTPS
app.UseStaticFiles(); // Habilita el servicio de archivos est�ticos

app.UseRouting(); // Habilita el enrutamiento de solicitudes

app.UseAuthorization(); // Habilita la autorizaci�n (aunque no se est� configurando en este ejemplo)

app.MapRazorPages(); // Mapea las Razor Pages a las rutas de la aplicaci�n

app.Run(); // Ejecuta la aplicaci�n

