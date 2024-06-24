using Microsoft.EntityFrameworkCore;

namespace Albumsss.Modelos
{
    // Definición del contexto de la base de datos para los álbumes
    public class AlbumContext : DbContext
    {
        // Constructor que recibe opciones para la configuración del contexto
        public AlbumContext(DbContextOptions<AlbumContext> options)
            : base(options)
        {

        }

        // DbSet representa una colección de todas las entidades en el contexto, o que se pueden consultar desde la base de datos
        public DbSet<Album> Albums { get; set; }

        // Método que se llama cuando se está creando el modelo de los datos
        // Permite configurar el esquema de la base de datos usando el ModelBuilder
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configura la entidad Album para mapear a la tabla "Album"
            modelBuilder.Entity<Album>().ToTable("Album");
        }
    }
}

