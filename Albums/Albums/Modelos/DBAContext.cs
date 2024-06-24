using Microsoft.EntityFrameworkCore;


namespace Albums.Modelos
{
    // Clase que representa el contexto de base de datos para la aplicación
    public class DBAContext : DbContext
    {
   
        public DBAContext(DbContextOptions<DBAContext> options)
            : base(options)
        { }

        // DbSet que representa la colección de álbumes en la base de datos
        public DbSet<Album> Albums { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Album>().ToTable("Album");
        }

    }
}


