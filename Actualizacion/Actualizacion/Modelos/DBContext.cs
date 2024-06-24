using Microsoft.EntityFrameworkCore;

namespace Actualizacion.Modelos
{
    public class DBContext:DbContext
    {
        public DbSet<Album> Albums { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseInMemoryDatabase("BDRazor");
        }
    }
}
